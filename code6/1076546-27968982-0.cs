    public abstract class Vehicle
    {
        public static Vehicle GetVehicle()
        {
            if (Context.IsMountain())
            {
                return new Truck();
            }
            else
            {
                return new Car();
            }
        }
        private class Car : Vehicle {}
        private class Truck : Vehicle {}
    }
