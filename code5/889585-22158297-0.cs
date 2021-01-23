    public string Name { get; private set; }
    public int Height { get; private set; }
    public int Weight { get; private set; }
    public ClassFirst(string name, int height, int weight)
    {
        if (name == null)
            throw new ArgumentNullException("name");
        if (height < 0)
            throw new ArgumentOutOfRangeException("height");
        if (weight < 0)
            throw new ArgumentOutOfRangeException("weight");
        Name = name;
        Height = height;
        Weight = weight;
    }
    public ClassFirst(string name)
        : this(name, 0, 0)
    { }
    public ClassFirst(string name, int height)
        : this(name, height, 0)
    { }
