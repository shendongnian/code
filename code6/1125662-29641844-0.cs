    class Program
    {
        static void Main(string[] args)
        {
            byte[] original = new byte[] { 99, 111, 98, 97, 112, 97, 115, 115, 99, 111, 98, 97, 112, 97, 115, 115 };
            byte[,] result = MakeAState(original);
            for (int row = 0; row < 4; row++)
            {
                for (int column = 0; column < 4; column++)
                {
                    Console.Write(result[row,column] + "   ");
                }
                Console.WriteLine();
            }
        }
        public static byte[,] MakeAState(byte[] block)
        {
            if (block.Length < 16)
            {
                return null;
            }
            byte[,] state = new byte[4,4];
            for (int i = 0; i < 16; i++)
            {
                state[i % 4, i / 4] = block[i];
            }
            return state;
        }
    }
