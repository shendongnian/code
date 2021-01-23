    /// <summary>
    /// Wrapper around 3x3 Blocks, allows reading from a range of [-8, 15] x [-8, 15].
    /// Not that writing is not supported.
    /// </summary>
    public class BlockContainer
    {
        private Block[,] _blocks;
        public const float DefaultValue = 128;
        public float this[int x, int y]
        {
            get
            {
                int blockX = 1, blockY = 1;
                //If the coordinates exceed the center Block, move to the adjacent Block.
                if (x < 0)
                {
                    blockX--;
                    x += Block.Size;
                }
                else if (x >= Block.Size)
                {
                    blockX++;
                    x -= Block.Size;
                }
                if (y < 0)
                {
                    blockY--;
                    y += Block.Size;
                }
                else if (y >= Block.Size)
                {
                    blockY++;
                    y -= Block.Size;
                }
                //Get the Block to read from - if there is no Block, just return the DefaultValue.
                //This is not ideal, but for now it works.
                Block block = _blocks[blockY, blockX];
                return (block != null) 
                    ? block[x, y] 
                    : DefaultValue;        
            }
        }
        public BlockContainer(Block[,] blocks)
        {
            if (blocks == null || blocks.GetLength(0) != 3 || blocks.GetLength(1) != 3)
                throw new ArgumentException("Expected 3x3 Blocks.");        
            _blocks = blocks;
        }
    }
