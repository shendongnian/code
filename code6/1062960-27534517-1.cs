        // 2d array to List
        List<List<int>> ar2list = new List<List<int>>()
        {
            new List<int>() { 1, 2, 3 },
            new List<int>() { 4, 5, 6 },
        };
        // adding item to List
        ar2list.Add(new List<int>() { 7, 8, 9 });
        // List to Jagged array conversion using Linq
        int[][] _arrConcat = ar2list.Select(Enumerable.ToArray).ToArray();
