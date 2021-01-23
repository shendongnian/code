        struct Cell
        {
            int Value;
        }
        public static void Main(string[] args)
        {
            unsafe
            {
                // result is: 4
                var intSize = sizeof(int);
                // result is: 4
                var structSize = sizeof(Cell);
            }
        }
