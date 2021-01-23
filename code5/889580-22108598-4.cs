    private int _weight = 150;
    public int Weight
    {
        get { return _weight; }
        set { _weight = value; }
    }
    public ClassSecond(string name, int height)
    {
        Height = height;    
    }
    public ClassSecond(string name, int height, int weight): this (name, height)
    {
        Weight = weight;
    }
