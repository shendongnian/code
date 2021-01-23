    int[][] factors = new int[][]
    {
        null,                   // 0 doesn't have prime factors
        new int[] { },          // 1 is the trivial case
        new int[] { 2 },
        new int[] { 3 },
        new int[] { 2, 2 },
        new int[] { 5 },
        new int[] { 2, 3},
        new int[] { 7 },
        new int[] { 2, 2, 2 },
        new int[] { 3, 3 },
        new int[] { 2, 5 },
        // ... and so on
    };
    int[] PrimeFactorsOf(int value)
    {
        if (value < factors.Length)
        {
            return factors[value];
        }
        else
        {
            // do the work
        }
    }
