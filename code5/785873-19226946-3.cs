    public interface DriverFactory<TDriver> where TDriver : Driver
    {
        TDriver New();
    }
    public class SpecialDriverFactory : IDriverFactory<SubclassOfDriver>
    {
        public SubclassOfDriver New()
        {
            return new SubclassOfDriver();
        }
    }
