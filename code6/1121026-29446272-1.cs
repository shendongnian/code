    [ServiceProvider(Providers.Employee)]
    public class A
    { 
        public void SomeMethod()
        {
            var provider = this.GetServiceProvider();
            Console.WriteLine(Dataclass.GetRecord(provider.ToString()));
        }
    }
