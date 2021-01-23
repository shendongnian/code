    public int Sum(params int[] integers)
    {
        int sum=0;
        foreach (var x in integers)
        {
            sum += x;
        }
        return sum;
    }
