    // using System.Linq;
    var xss = new int[][]
    {
        new int[] { 6, 13, 24, 31, 35 },
        new int[] { 1, 2, 3, 6, 1 }
    };
    foreach (int[] xs in xss)
    {
        if (xs.Where((_, i) => i < xs.Length - 1 && xs[i] == 6 && xs[i + 1] == 1).Any())
        {
            // list contains a 6, followed by a 1
        }
    }
