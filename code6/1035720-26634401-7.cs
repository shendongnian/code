    public class StartupMessageWriter : IStartable
    {
       public void Start()
       {
          Console.WriteLine("App is starting up!");
       }
    }
    ....
    
    var builder = new ContainerBuilder();
    builder
        .RegisterType<StartupMessageWriter>()
        .As<IStartable>()
        .SingleInstance(); 
