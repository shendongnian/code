    public Restaurant(string restaurantName, int capacity)
    {
        this.Name = restaurantName;
        this.Chain = null;
        this.SeatingCapacity = capacity;
        this.Smoking = false;
        this.LastMonthSales = MinSales;
        this.LastMonthCosts = MinCosts;
        this.OpenDays = new List<DayOfWeek>();
    }
    public Restaurant(string restaurantName) : this(restaurantName, MinSeats)
    {}
    public Restaurant() : this(DefaultName)
    {}
