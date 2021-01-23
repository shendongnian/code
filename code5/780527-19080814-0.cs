    public class AppHost
    {
       ...
       public void Configure(Container container)
       {
           Plugins.Add(new ProtoBufFormat());
       }
    }
