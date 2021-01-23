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
    
            PrintArray(source);
            Move(source, new pos() { row = 2, col = 1 }, new pos() { row = 0, col = 3 });
    
            Console.ReadKey();
        }
    
        static void Move(string[,] arr, pos from, pos to)
        {
            MoveV(arr, new pos() { row = 2, col = 1 }, new pos() { row = 0, col = 3 });
            PrintArray(arr);
    
            MoveH(arr, new pos() { row = 2, col = 1 }, new pos() { row = 0, col = 3 });
            PrintArray(arr);
        }
        // Moves an item verticaly.
        static void MoveV(string[,] arr, pos from, pos to)
        {
            // Gets the distance to move.
            int delta = to.row - from.row;
            // Gets the direction of the movement (+ or -)
            int mov = Math.Sign(delta);
            // Moves an item.
            for (int row = from.row, i = 0; i < Math.Abs(delta); row += mov, i++)
            {
                Swap(arr, new pos() { row = row, col = from.col }, new pos() { row = row + mov, col = from.col });
            }
        }
    
        // Moves an item horizonataly.
        static void MoveH(string[,] arr, pos from, pos to)
        {
            int delta = to.col - from.col;
            int mov = Math.Sign(delta);
            for (int col = from.col, i = 0; i < Math.Abs(delta); col += mov, i++)
            {
                Swap(arr, new pos() { row = to.row, col = col }, new pos() { row = to.row, col = col + mov });
            }
        }
    
        // Swaps two items on each move.
        static void Swap(string[,] arr, pos from, pos to)
        {
            string val = arr[to.row, to.col];
            arr[to.row, to.col] = arr[from.row, from.col];
            arr[from.row, from.col] = val;
        }
    
        // Print the array to the console.
        static void PrintArray(string[,] arr)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 4; i++)
            {
                sb.AppendLine(string.Format("{0} {1} {2} {3}", getval(arr, i, 0), getval(arr, i, 1), getval(arr, i, 2), getval(arr, i, 3)));
            }
            sb.AppendLine("");
            Console.Write(sb.ToString());
        }
    
        static string getval(string[,] arr, int row, int col)
        {
            return string.IsNullOrWhiteSpace(arr[row, col]) ? " " : arr[row, col];
        }
    }
    
    struct pos
    {
        public int row;
        public int col;
    }
