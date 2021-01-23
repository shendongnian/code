    public class AlternateVehicleMap : VehicleMap
    {
        public AlternateVehicleMap()
        {
            EntityName("IAbsolutlyWantOnlyTheBaseClass");
            Readonly();   // to make sure noone messes up
        }
    }
    
    List<Vehicle> vehicles = session.CreateCriteria<Vehicle>("IAbsolutlyWantOnlyTheBaseClass").Add(Expression.Gt("WheelsCount", 2).List<Vehicle>();
