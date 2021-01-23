    public static void Main() {
        VehicleRepository repository = ...;
        // Notice that we skip accessing the vehicles member
        // because way expressed (by implementing IEnumerable<T>)
        // that this is a collection. Now you can use OfType<T> directly.
        repository.OfType<Car>(); 
    }
