    class MyContactListener : ContactListener
    {
        public override void Add(ContactPoint point)
        {
            Body bodyA = point.Shape1.GetBody();
            Body bodyB = point.Shape2.GetBody();
            
            Entity typeA = (Entity)bodyA.GetUserData();
            Entity typeB = (Entity)bodyB.GetUserData();
            // Ball collision with Enemy
            if ((typeA is Enemy && typeB is Ball) || (typeB is Ball && typeA is Enemy))
            {
                // Do something based on the collision
            }
