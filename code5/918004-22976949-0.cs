    public interface IInjectable
    {
        string Test();
    }
    public class Injectable : IInjectable
    {
        public string Test()
        {
            return this.GetType().ToString();
        }
    }
    public class InjectTarget
    {
        public IInjectable Injectable
        {
            get;
            set;
        }
    }
    static class Program
    {
        static void Main()
        {
            ObjectFactory.Configure(x =>
            {
                //Setter injection
                x.Policies.FillAllPropertiesOfType<IInjectable>().Use<Injectable>();
                //Standard registration
                x.For<IInjectable>().Use<Injectable>();
                x.For<InjectTarget>().Singleton().Use<InjectTarget>();
            });
            var test = ObjectFactory.GetInstance<InjectTarget>();
            Console.WriteLine(test.Injectable.Test()); //WindowsFormsApplication3.Injectable
        }
    }
