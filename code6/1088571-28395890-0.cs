    private List<Car> Fleet = new List<Car>()
    {
       new Car("Toyota", "Corola","YI348J", 2007, 7382.33),
       new Car("Renault", "Megane","ZIEKJ", 2001, 1738.30),
       new Car("Fiat", "Punto","IUE748", 2004, 3829.33)
    };
    public void addToFleet(String make, String model, String registration, int year, Double costPrice)
    {
        if(Fleet.Any(car => car.Registration == registration))
        {
           // already in there
        } 
        else
        {
          Fleet.Add(new Car(make, model, registration, year, costPrice));
        }
    }
