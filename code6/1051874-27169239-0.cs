    class Program
    {
        static void Main(string[] args)
        {
            var source = new[,]
            {
                { "r", "b", "g", "y" },
                { "r", "b", "g", "y" },
                { "r", string.Empty, "g", "y" },
                { "r", "b", "g", "y" }
            };
    
            Move(source, new pos() { row = 2, col = 1 }, new pos() { row = 0, col = 3 });
        }
    
        static void Move(string[,] arr, pos from, pos to)
        {
            MoveV(arr, new pos() { row = 2, col = 1 }, new pos() { row = 0, col = 3 });
            MoveH(arr, new pos() { row = 2, col = 1 }, new pos() { row = 0, col = 3 });
        }
        static void MoveV(string[,] arr, pos from, pos to)
        {
            int delta = to.row - from.row;
            int mov = Math.Sign(delta);
            for (int row = from.row, i = 0; i < Math.Abs(delta); row += mov, i++)
            {
                Swap(arr, new pos() { row = row, col = from.col }, new pos() { row = row + mov, col = from.col });
            }
        }
    
        static void MoveH(string[,] arr, pos from, pos to)
        {
            int delta = to.col - from.col;
            int mov = Math.Sign(delta);
            for (int col = from.col, i = 0; i < Math.Abs(delta); col += mov, i++)
            {
                Swap(arr, new pos() { row = to.row, col = col }, new pos() { row = to.row, col = col + mov });
            }
        }
    
        static void Swap(string[,] arr, pos from, pos to)
        {
            string val = arr[to.row, to.col];
            arr[to.row, to.col] = arr[from.row, from.col];
            arr[from.row, from.col] = val;
        }
    }
    
    struct pos
    {
        public int row;
        public int col;
    }
