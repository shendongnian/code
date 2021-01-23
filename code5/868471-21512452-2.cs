    class Program
    {
        private const float OneNinth = 1.0f / 9;
        /// <summary>
        /// Simple convolution filter that does a rectangle blur.
        /// </summary>
        private static float[,] Filter = new float[,]
        {
            {OneNinth, OneNinth, OneNinth},
            {OneNinth, OneNinth, OneNinth},
            {OneNinth, OneNinth, OneNinth},
        };
        /// <summary>
        /// Simple 4x2 terrain example. For demo purposes, each block consists of only 1 value.
        /// </summary>
        private static Block[,] Terrain = new Block[,]
        {
            { new Block(8f), new Block(16f), new Block(24f), new Block(32f) },
            { new Block(8f), new Block(32f), new Block(16f), new Block(8f) },
        };
        public static void Main(string[] args)
        {
            BlockContainer container = GetBlockContainer(2, 0);    //The Block with only 24f values.
            Block result = Apply3x3Filter(Filter, container);
            Console.WriteLine(string.Join(Environment.NewLine, result.TextLines));
            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }
        /// <summary>
        /// Gets the 3x3 Block area around (terrainX, terrainY) as a BlockContainer.
        /// </summary>
        private static BlockContainer GetBlockContainer(int terrainX, int terrainY)
        {
            Block[,] readBlocks = new Block[3, 3];
            for (int blockY = -1; blockY <= 1; blockY++)
            {
                for (int blockX = -1; blockX <= 1; blockX++)
                {
                    int sourceX = terrainX + blockX;
                    int sourceY = terrainY + blockY;
                    if (sourceX >= 0 && sourceX < 4 && sourceY >= 0 && sourceY < 2)
                        readBlocks[blockY + 1, blockX + 1] = Terrain[sourceY, sourceX];
                }
            }
            return new BlockContainer(readBlocks);
        }
        private static Block Apply3x3Filter(float[,] filter, BlockContainer container)
        {
            Block resultBlock = new Block(0.0f);
            for (int y = 0; y < Block.Size; y++)
            {
                for (int x = 0; x < Block.Size; x++)
                {
                    //Read the 3x3 area around (x, y) and multiply them with the values in the 
                    //convolution filter.
                    float sum = 0.0f;
                    for (int fy = -1; fy <= 1; fy++)
                    {
                        for (int fx = -1; fx <= 1; fx++)
                            sum += (container[x + fx, y + fy] * filter[fy + 1, fx + 1]);
                    }
                    //The sum is our averaged value for (x, y).
                    resultBlock[x, y] = sum;
                }
            }
            return resultBlock;
        }
    }
