    List<int> split(int num, int splitBy)
    {
        List<int> r = new List<int>();
        int v = Convert.ToInt32(num / splitBy);
        for (int i = 1; i <= v; i++)
        {
            r.Add(splitBy);
        }
        if (num % splitBy != 0)
            r.Add(num % splitBy);
        return r;
    }
