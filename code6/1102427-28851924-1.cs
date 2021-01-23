    public void Main()
    {
        CallNullable(23, null);
    }
    public void CallNullable(int? x, int? y)
    {
        int z = (x.HasValue ? x.Value : 0) + (y.HasValue ? y.Value : 0);
    }
