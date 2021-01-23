    public class Something : ISomething 
    {
        private readonly IEnvironment environment;
        public void SomeMethod(IEnvironment environment)
        {
           this.environment = environment;
        }
    
        public void SomeMethod()
        {
           this.environment.DoSomething();
        }
    }
