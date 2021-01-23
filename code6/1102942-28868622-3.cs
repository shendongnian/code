    static int[] IndexToCoordinates(int i, Array arr)
    {
        var dims = Enumerable.Range(0, arr.Rank)
            .Select(arr.GetLength)
            .Reverse()
            .ToArray();
        Func<int, int, int> product = (i1, i2) => i1 * i2;
        return dims.Select((d, n) => (i/dims.Take(n).Aggregate(1, product))%d).ToArray();
    }
