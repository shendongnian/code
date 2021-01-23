    public class Program
    {
        private static void Main(string[] args)
        {
            var host = new CompositionHost();
            new CompositionContainer(new AssemblyCatalog(typeof(Plugin).Assembly)).ComposeParts(host);
            var plugin = host.Plugin;
            plugin.Method();
            Console.ReadLine();
        }
        private class CompositionHost: IPartImportsSatisfiedNotification
        {
            [Import(typeof (IPlugin))] private IPlugin _plugin;
            public IPlugin Plugin { get; private set; }
            public void OnImportsSatisfied()
            {
                Plugin = _plugin;
            }
        }
    }
    public interface IPlugin
    {
        void Method();
    }
    [Export(typeof(IPlugin))]
    public class Plugin : IPlugin
    {
        public void Method()
        {
            //Method Blocks
            Thread.Sleep(5000);
        }
    }
	
