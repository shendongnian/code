    public static void Main() {
       VehicleRepository repository = ...
      
       // Assuming index zero is a truck
       Truck truck = (Truck)repository.GetVehicleByID(0);
       truck.LoadCapacity = ...
    }
