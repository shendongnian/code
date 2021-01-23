    public static void Main() {
       VehicleRepository repository = ...
       // Assume we're storing off the typename in the UI dropdown.
       // so that when the user selects it, we automatically have the correct
       // type name we want to filter by.
       String truckTypeName = typeof(Truck).GetType().ToString();      
       // Filter only by those types with a matching type name. Inefficient,
       // but it does avoid reflection.
       repository.Where(vehicle => vehicle.GetType().ToString() == truckTypeName)
    }
