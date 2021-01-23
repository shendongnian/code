    public void GetToken()
    {
        numQuarters++; // ++ 'is increase by one', guess what -- will do
        numTokens--;
    }
    public int CountTokens()
    {
        return numTokens;
    }
    public void Reset()
    {
        numQuarters = 0;
        numTokens = 100;
    }
