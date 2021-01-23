    public class Something : ISomething 
    {
        private readonly IEnvironment environment;
        public Something (IEnvironment environment)
        {
           this.environment = environment;
        }
    
        public void SomeMethod()
        {
           environment.DoSomething();
        }
    }
