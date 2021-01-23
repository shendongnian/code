    delegate bool CheckVehicle(dynamic v); // predicate template
    private static bool CheckCarBlue(dynamic v)
    {
        return v.Vehicle == "Car" && v.Color == "Blue";
    }
    private static bool CheckTruckV8(dynamic v)
    {
        return v.Vehicle == "Truck" && v.Engine == "V8";
    }
    private static bool CheckCarV4(dynamic v)
    {
        return v.Vehicle == "Car" && v.Engine == "V4";
    }
