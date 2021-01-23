    public static int Sum(this IEnumerable<int> source)
    {
        int sum = 0;
        foreach(int item in source)
        {
            sum += item;
        }
        return sum;
    }
