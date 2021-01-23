    public struct blocks
    {
        public Int32 xb;
        public Int32 yb;
        public Int32 size;
    };
    namespace test
    {
        class Program
        {
            static List<blocks> blocks1;
            static void Main(string[] args)
            {
                blocks1 = new List<blocks>();
                for (int y = 1; y < 5; y++)
                {
                    for (int x = 1; x < 5; x++)
                    {
                        blocks newBlock = new blocks();
                        newBlock.xb = x * 2;
                        newBlock.yb = y * 2;
                        newBlock.size = 2;
                        blocks1.Add(newBlock);
                    }
                }
            }
        }
    }
