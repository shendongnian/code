    // We assume that we created a World class that can get a block based on
    // a Vector2D.
    var playerBlock = World.GetBlockByPosition(player.Position);
    
    // Set the TopLeft position of the minimap accordingly.
    Vector2 minimapTopLeft = new Vector(500, 100);
    // Draw each 4 pixel block from that TopLeft position;
    for (int i = -30; i <= 30; i++)
    {
        for (int j = -30; j <= 30; j++)
        {
            // Make sure you do proper bounds checking in GetBlock(x, y).
            int blockType = World.GetBlock(i, j).Type;
            // Draw the 4 pixel blocks based on the i and j vars and the 
            // minimapTopLeft as offset.
            switch (blockType)
            {
                case 1:
                    // Draw dirt.
                    break;
                case 2:
                    // Etc.
                    break;
                default:
                    // Draw default black block.
                    break;
            }
        }
    }
