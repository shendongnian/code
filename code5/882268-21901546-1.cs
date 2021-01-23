    void OnCollisionEnter(Collider collider)
    {
        foreach(CollisionPoint contact in collider.contacts)
        {
            //Do something
        }
    }
