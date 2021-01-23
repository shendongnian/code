    public class GreetingService : IGreetingService
    {
        public Greeting DoWork(string name)
        {
            return new Greeting {Str = string.Format("Hello {0}", name)};
        }
    }
