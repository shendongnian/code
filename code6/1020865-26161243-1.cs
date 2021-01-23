    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix=new int[,] {
                { 1, 2, 3, 4 },
                { 1, 3, 4, 2 },
                { 2, 3, 4, 1 },
                { 2, 4, 1, 3 } };
            // This returns the #of collisions in each column
            Debug.WriteLine(CheckColumn(matrix, 0));    // 2
            Debug.WriteLine(CheckColumn(matrix, 1));    // 1
            Debug.WriteLine(CheckColumn(matrix, 2));    // 1
            Debug.WriteLine(CheckColumn(matrix, 3));    // 0
        }
        static int CheckColumn(int[,] matrix, int column)
        {
            int[] data=new int[matrix.GetLength(0)];
            for(int i=0; i<data.Length; i++)
            {
                data[i]=matrix[i, column];
            }
            var hist=data.GroupBy(i => i)
                .OrderByDescending(g => g.Count())
                .Select(g => new { Num=g.Key, Dupes=g.Count()-1 })
                .Where(h=>h.Dupes>0);
            return hist.Count()>0?hist.Sum(h=>h.Dupes):0;
        }
    }
