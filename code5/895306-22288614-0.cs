        public class Player : MovingGameObject
        {
        ...
        public override void Update(GameTime gameTime)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            this.beingMoved = false;
            if (canBeDameged)
            {
                if (!canTakeDamage)
                {
                    timeSinceDamage += (float)gameTime.ElapsedGameTime.Milliseconds;
                    if (timeSinceDamage >= damegeDelay)
                    {
                        canTakeDamage = true;
                        timeSinceDamage = 0;
                    }
                }
            }
            if (hasInput)
            {
                string newAnimation = "Stand";
                if (Input.KeyDown(leftKey0) ||
                    Input.KeyDown(leftKey1))
                {
                    speed.X -= accelerationX * elapsed;
                    beingMoved = true;
                    flipped = true;
                    newAnimation = "Walk";
                }
                if (Input.KeyDown(rightKey0) ||
                    Input.KeyDown(rightKey1))
                {
                    speed.X += accelerationX * elapsed;
                    beingMoved = true;
                    flipped = false;
                    newAnimation = "Walk";
                }
                if ((Input.KeyPressed(jumpKey0) ||
                    Input.KeyPressed(jumpKey1) ||
                    Input.KeyPressed(jumpKey2)))
                {
                    Jump();
                    newAnimation = "Jump";
                }
                if ((Input.KeyDown(downKey0) ||
                    Input.KeyDown(downKey1)))
                {
                    speed.Y += Gravity.Y * 3 * elapsed;
                }
                HandelAnimations(newAnimation);
                //repositionCamera(); --> replace it after base.Update(gameTime)
            }
            base.Update(gameTime);
            repositionCamera(); // place here!
        }
        ...
        }
