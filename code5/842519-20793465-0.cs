            Rectangle sandBitRect = new Rectangle()
            protected override void Draw(GameTime gameTime)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
                spriteBatch.Begin();
                foreach (SandBit sandBit in sandBitManager.grid)
                {
                    Point p = sandBit.Position;
                    sandBitRect.Left = p.X;
                    sandBitRect.Top = p.Y;
                    sandBitRect.Width = sandBit.SIZE;
                    sandBitRect.Height = sandBit.SIZE;
                    spriteBatch.Draw(square, sandBitRect, Color.White);
                }
                spriteBatch.End();
                base.Draw(gameTime);
            }
