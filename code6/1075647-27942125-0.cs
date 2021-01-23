    public List<City> Tour {get; private set;}
    public Tour(List<City> tour)
    {
        this.Tour = new List<City>();
        foreach (var city in tour)
          this.tour.Add((City)city.Clone());    
    }
