    enum FuelType
    {
        Gas = 0x0001, etc...
    }
    class Fuel
    {
        readonly FuelType TypeId;
        readonly FuelType Exclude;
        public Fuel(FuelType type, FuelType exclude)
        {
            TypeId = type;
            Exclude = exclude;
        }
    }
