    void OnCollisionEnter(Collision collision)
    {
    foreach (ContactPoint contact in collision.contacts) 
    {
        if(contact.thisCollider == collider1)
        {
            float cp = contact.point.x - transform.position.x;
            contact.otherCollider.attachedRigidbody.AddForce(reflectionForce * cp, 0.0f, 0.0f);
            float maxSpeed = 2.0f; //for example
            Vector3 vel = contact.otherCollider.attachRigidbody.velocity;
            contact.otherCollider.attachRigidbody.velocity = Vector3.ClampMagnitude(vel,maxSpeed);
        }
    }
}
