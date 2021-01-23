        Vector2 Velocity { get; set; }
        Vector2 relative { get; set; }
        public void Update(GameTime gameTime, Vector2 center)
        {
            this.currentCentre = center;
            Vector2 calculatedDirection = CalculateDirection();
            if (speed > 0f || speed < 0f)
            {
                Velocity = calculatedDirection * speed * 0.1f;
                relative = relative - Velocity;
                position = currentCentre + relative;
            }
        }
