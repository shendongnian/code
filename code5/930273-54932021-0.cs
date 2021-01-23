     void OnCollisionEnter(Collision collision)
        {
     
            if (collision.gameObject.tag.Equals("ground"))
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0); // set y velocity to zero
                rigidbody.AddForce(new Vector2(0, 400)); // some constant force here
    
            }
    
        }
