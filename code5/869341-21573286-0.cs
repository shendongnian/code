      ` bool IsDraging = false;
        protected override void Update(GameTime gameTime)
        {
            if (IsDraging)
            {
                MovePlayer();
            }
            while (TouchPanel.IsGestureAvailable)
            {
                // read the next gesture
                GestureSample gesture = TouchPanel.ReadGesture();
                // has the user tapped the screen?
                switch (gesture.GestureType)
                {
                    case GestureType.HorizontalDrag:
                        IsDraging = true;
                        break;
                    case GestureType.DragComplete: IsDraging = false; break;
                }
            }
        }
        void MovePlayer()
        {
            if (gesture.delta.X > 0)
                playerPosition.X += playerSpeed;
            else
                playerPosition.X -= playerSpeed;
        }
