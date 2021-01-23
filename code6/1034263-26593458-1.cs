        Vector2 balloonOrigin, balloonPosition;
        Vector2 balloonVelocity;
        private float MaxDistance = 1920; // Reduce this value to slow down the balloon.
        public static float AngleBetweenVectors(Vector2 v1, Vector2 v2) { return (float)Math.Atan2(v2.Y - v1.Y, v2.X - v1.X); }
        public void test()
        {
            //System.Windows.Input.MouseState currentMouseState = System.Windows.Input.Mouse.GetState();
            // Get the current mouse position
            Vector2 mousePosition = new Vector2(currentMouseState.X, currentMouseState.Y);
            // Get the distance between the balloon and the mouse.
            float distance = Vector2.Distance(mousePosition, balloonPosition);
            // You can change the max distance to make the sprite move faster or slower.
            // Currently it may move to fast or to slow for you to know a difference. 
            balloonVelocity = AngleBetweenVectors(balloonPosition, mousePosition) * (distance / MaxDistance);
            // Set the balloons position to the new velocity.
            balloonPosition += balloonVelocity;
        }
