    T[][] Permutations<T>(T[][] vals)
    {
        int numCols = vals.Length;
        int numRows = vals.Aggregate(1, (a, b) => a * b.Length);
    
        var results = Enumerable.Range(0, numRows)
                                .Select(c => new T[numCols])
                                .ToArray();
    
        int repeatFactor = 1;
        for (int c = 0; c < numCols; c++)
        {
            for (int r = 0; r < numRows; r++)
                results[r][c] = vals[c][r / repeatFactor % vals[c].Length];
            repeatFactor *= vals[c].Length;
        }
    
        return results;
    }
