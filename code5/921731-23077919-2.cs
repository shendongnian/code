    public Point Point
    {
        get { return _point; }
        set
        {   // If UpdatePosition() tries to move the ball beyond the boundaries in one tick move the ball to the boundaries
            if(value.Y > view.Boundaries.Height || value.Y < 0) 
            {
                _point = new Point(value.X, view.Boundaries.Height);
                Collision(CollisionType.Boundary); // Also raise the collision event
            }
            //If the ball is going to pass the X boundaries of the map then a player should score and the ball should reset
            if (value.X > view.Boundaries.Width || value.X < 0)
            {
                if (angle > 90) // If the angle of the ball of the ball is above 90 degrees then the left paddle was the shooter
                {               // So he should score
                    var scoringPlayer = Array.Find(controller.Players, player => player.Paddle.Orientation.Equals(Orientation.Left));
                    controller.PlayerScore(scoringPlayer);
                    Center(scoringPlayer);
                } 
                else // If not, then it's the right paddle
                {
                    var scoringPlayer = Array.Find(controller.Players, player => player.Paddle.Orientation.Equals(Orientation.Right));
                    controller.PlayerScore(scoringPlayer);
                    Center(scoringPlayer);
                }
            }
            // If the ball will collide with a player paddle then raise collision event
            if (controller.Players.Any(player => player.Paddle.Position.Equals(value)))
            {
                Collision(CollisionType.Paddle);
                _point = value;
            }
            _point = value; // <--- This always gets set - even after you call Center above
        }
    }
