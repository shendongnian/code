    public City(string name, decimal latitude, decimal longitude, int? id = null) 
        : base(id)
    {
        Name = name;
        Coordinate = coordinate;
        SetLocation(latitude, longitude);
    }
