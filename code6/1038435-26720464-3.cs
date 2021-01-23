    public static MotionBlock[] getImageBlocks(LockBitmap lockBitmap)
    {
        int surface = (lockBitmap.Width / 8) * (lockBitmap.Height / 8);
        MotionBlock[] blocks = new MotionBlock[surface];
        MotionBlock block = new MotionBlock();
        int blockIndex = 0;
        for (int imageX = 0; imageX < lockBitmap.Width; imageX++)
        {
            for (int imageY = 0; imageY < lockBitmap.Height; imageY++)
            {
                // Get the block-level X and Y coordinates
                int blockX = imageX % 8;
                int blockY = imageY % 8;
                    
                // If we are at the start of a new block, create it
                if (blockX == 0 && blockY == 0)
                {
                    block = new MotionBlock {X = imageX, Y = imageY};
                }
                // Set the gray values of the current block and output to console
                block.GrayValues[blockX, blockY] = lockBitmap.GetPixel(imageX, imageY).R;
                Console.WriteLine(block.grayValues[blockX, blockY]);
                // If we are at the end of a block, save it to our array
                if (blockX == 7 && blockY == 7)
                {
                    blocks[blockIndex] = block;
                }
                // Increment our block array index
                blockIndex++;
            }
        }
        return blocks;
    }
