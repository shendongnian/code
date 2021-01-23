    public static void Main() {
        VehicleRepository repository = ...;
        // Notice that we skip accessing the vehicles member
        // because by implementing IEnumerable<T> this class
        // becomes a collection. Now you can use OfType<T> directly.
        repository.OfType<Car>(); 
    }
