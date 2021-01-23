    class CompositeObject //use a better name that fits your context..
    {
      Journey journey; public Journey Property { get; private set; }
      Vehicle vehicle; public Vehicle Property { get; private set; }
    
      public CompositeObject(Journey journey, Vehicle vehicle)
      {
        this.journey = journey;
        this.vehicle = vehicle;
      }
    
      public override string ToString()
      {
        return this.vehicle.ToString() + " | " + this.journey.ToString();
      }
    }
