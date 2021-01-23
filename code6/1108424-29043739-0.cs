    void OnCollisionEnter(Collision collision)
    {
    foreach (ContactPoint contact in collision.contacts) 
    {
        if(contact.thisCollider == collider1)
        {
            float cp = contact.point.x - transform.position.x;
            contact.otherCollider.attachedRigidbody.velocity = new Vector3(reflectionForce * cp, 0.0f, 0.0f);
        }
    }
}
