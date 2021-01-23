        Vector2 balloonOrigin, balloonPosition;
        Vector2 balloonVelocity;
        private float MaxDistance = 1920; // Reduce this value to slow down the balloon.
        private Vector2 StandardVelocity = new Vector2(20);
        public void test()
        {
            //System.Windows.Input.MouseState currentMouseState = System.Windows.Input.Mouse.GetState();
            // Get the current mouse position
            Vector2 mousePosition = new Vector2(currentMouseState.X, currentMouseState.Y);
            // Get the distance between the balloon and the mouse.
            float distance = Vector2.Distance(mousePosition, balloonPosition);
            // You can change the standard velocity / or the max distance to make the sprite move faster or slower.
            // Currently it may move to fast or to slow for you to know a difference. 
            balloonVelocity = StandardVelocity * (distance / MaxDistance);
            // Set the balloons position to the new velocity.
            balloonPosition += balloonVelocity;
        }
