    public class MyModule : Module
    {
        private static readonly ILog Log = LogManager.GetLogger<MyModule>();
    
        protected override void Load(ContainerBuilder builder)
        {
            Log.Debug(msg => msg("Hello")); // log whatever you want here
        }
    }
