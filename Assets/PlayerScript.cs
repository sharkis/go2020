using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float Speed = 10.0f;
    public GameObject shotPrefab;
    Rigidbody2D rigidbody2d;
    Vector2 lookDirection = new Vector2(1, 0);

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        // only change look direction if there is horizontal input
        if(horizontal != 0)
        {
            lookDirection.Set(horizontal, 0);
            lookDirection.Normalize();
        }
        Vector2 position = transform.position;
        position.x = position.x + Speed * horizontal * Time.deltaTime;
        transform.position = position;

        if (Input.GetButtonDown("Fire1"))
        {
            // jump
        }

        if (Input.GetButtonDown("Fire3"))
        {
            Launch();
        }
    }

    void Launch()
    {
        GameObject projectileObject = Instantiate(shotPrefab, rigidbody2d.position, Quaternion.Euler(0f,(lookDirection.x - 1)*90,0f));
    }
}
