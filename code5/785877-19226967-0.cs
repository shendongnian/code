    public class Driver { }
    public class SubclassOfDriver : Driver { }
    public interface IDriverService<T> where T : Driver
    {
        T New();
    }
    public class SpecificService : IDriverService<Driver>
    {
        public Driver New()
        {
            return ...;
        }
    }
    public class OtherSpecificService : IDriverService<SubclassOfDriver>
    {
        public SubclassOfDriver New()
        {
            return ...;
        }
    }
