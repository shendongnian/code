        public bool ProcessChunk(int x, int y)
        {
            // Create render target
            using (RenderTarget2D target = new RenderTarget2D(Game.CurrentDevice, 16 * 48, 16 * 48,
                false, SurfaceFormat.Color, DepthFormat.Depth24))
            {
                // Set render target
                Game.CurrentDevice.SetRenderTarget(target);
                // Clear back buffer
                Game.CurrentDevice.Clear(Color.Black * 0f);
                // Begin drawing
                Game.spriteBatch.Begin(SpriteSortMode.Texture, BlendState.AlphaBlend);
                // Get block coordinates
                int bx = x * 48,
                    by = y * 48;
                // Draw blocks
                int count = 0;
                foreach (WorldSection section in Sections)
                {
                    // Continue if section is out of chunk bounds
                    if (section.X >= bx + 48) continue;
                    // Draw all tiles within the screen range
                    for (int ax = 0; ax < 48; ax++)
                        for (int ay = 0; ay < 48; ay++)
                        {
                            // Get the block character
                            char b = section.Blocks[ax + bx - section.X, ay + by];
                            // Draw the block unless it's an empty block
                            if (b != '0')
                            {
                                Processor.Blocks[b.ToString()].DrawBlock(new Vector2(ax, ay), true);
                                count++;
                            }
                        }
                }
                // End drawing
                Game.spriteBatch.End();
                // Clear target
                target.GraphicsDevice.SetRenderTarget(null);
                // Set texture
                if (count > 0)
                {
                    // Create texture
                    Chunks[x, y] = new Texture2D(Game.CurrentDevice, target.Width, target.Height, true, target.Format);
                    // Set data
                    Color[] data = new Color[target.Width * target.Height];
                    target.GetData<Color>(data);
                    Chunks[x, y].SetData<Color>(data);
                    // Return true
                    return true;
                }
            }
            // Return false
            return false;
        }
