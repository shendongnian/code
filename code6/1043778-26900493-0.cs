    static Array Factors(double value)
    {
        List<int> factors = new List<int>{};
        int counter = 0;
        for (int i = 1; i <= (0.5 * value); i++)
        {
            if (value % 1 == 0)
            {
                factors.Add(i);
                counter++;
            }
        }
        return factors.ToArray();
    }
