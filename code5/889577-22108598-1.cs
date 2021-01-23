    public ClassSecond(string name, int height)
    {
        Height = height;    
    }
    public ClassSecond(string name, int height, int weight): this (name, height)
    {
        Weight = weight;
    }
