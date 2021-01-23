    public ClassFirst(string name, int height, int weight)
    {
        Name = name;
        Height = height;
        Weight = weight;
    }
    public ClassFirst(string name, int height)
        : this(name, height, 150)
    { }
