    public class MotorcycleDriveableStrategy : IDriveableStrategy
    {
        //What i would like to do
        public bool IsDriveable(ITransport transport)
        {
            var mc = transport as Motorcycle;
            if (mc == null) return false;
            return mc.NumWheels > 2;
        }
    }
