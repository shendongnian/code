                if (lastPosition.Y < position.Y)
                {
                    initialFrame = 15;
                    lastFrame = 19;
                }
                if (position.Y < lastPosition.Y)
                {
                    initialFrame = 10;
                    lastFrame = 14;
                }
                if (position.X > lastPosition.X)
                {
                    initialFrame = 5;
                    lastFrame = 9;
                }
                if (position.X < lastPosition.X)
                {
                    initialFrame = 0;
                    lastFrame = 4;
                }
                currentFrame = initialFrame;
                totalFrame = lastFrame;
                timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
                if (timeSinceLastFrame > milisecondsPerFrame)
                {
                    timeSinceLastFrame -= milisecondsPerFrame;
                    currentFrame++;
                    if (currentFrame == totalFrame)
                        currentFrame = 0;
                }       
            }
