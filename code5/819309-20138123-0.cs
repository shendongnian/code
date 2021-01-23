    public static int[] SplitIntoPercentage(this double[] input)
    {
        int[] results = new int[input.Length];
        for (int i = 0; i < input.Length - 1; i++)
        {
            results[i] = (int)Math.Round(input[i] * 100, MidpointRounding.AwayFromZero);
        }
        results[input.Length - 1] = 100 - results.Sum();
        return results;
    }
