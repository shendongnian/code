    public class BingoBoard
    {
        public const int BoardDimension = 5;
        readonly int[,] board = new int[BoardDimension, BoardDimension];
        public BingoBoard()
        {
            // In column 1 it can only be a number between 1-15 and in column 2 number 16-30 and so on up until column 5 with a number between 61-75.
            for (int iRow = 0; iRow < board.GetLength(0); iRow++)
            {
                var col = Enumerable.Range(iRow * 3 * board.GetLength(1) + 1, 3 * board.GetLength(1)).Shuffle().Take(board.GetLength(1)).ToArray();
                for (int iCol = 0; iCol < board.GetLength(1); iCol++)
                    board[iRow, iCol] = col[iCol];
            }
        }
        public int[,] Board
        {
            get
            {
                return board;
            }
        }
    }
    public static class RandomProvider
    {
        // Adapted from http://csharpindepth.com/Articles/Chapter12/Random.aspx
        private static int seed = Environment.TickCount;
        [ThreadStatic]
        static Random random;
        public static Random GetThreadRandom()
        {
            if (random == null)
                random = new Random(Interlocked.Increment(ref seed));
            return random;
        }
    }
    public class FisherYatesShuffle 
    {
        public void ShuffleInPlace<T>(T[] array)
        {
            var randomizer = RandomProvider.GetThreadRandom();
            // http://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle#The_modern_algorithm , second version.
            for (int i = 0; i < array.Length; i++)
            {
                // http://msdn.microsoft.com/en-us/library/2dx6wyd4%28v=vs.110%29.aspx
                var j = randomizer.Next(i, array.Length); // i = inclusive lower bound; array.Length = The exclusive upper bound of the random number returned
                array.Swap(i, j);
            }
        }
    }
    public static class ListExtensions
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> list)
        {
            var scrambled = list.ToArray();
            new FisherYatesShuffle().ShuffleInPlace(scrambled);
            return scrambled;
        }
        public static void Swap<T>(this T[] list, int i, int j)
        {
            if (list == null)
                throw new ArgumentNullException();
            if (i != j)
            {
                T temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }
    }
