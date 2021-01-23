    public static int Sum(this IEnumerable<int> source)
    {
        int sum = 0;
        IEnumerator<int> iterator = source.GetEnumerator();
        while(iterator.MoveNext())
        {
            int item = iterator.Current;
            sum += item;
        }
        return sum;
    }
