    class Program
    {
        static void Main(string[] args)
        {
            var pluginHost = new PluginHost();
            //Console.WriteLine("\r\nProgram:\r\n" + string.Join("\r\n", AppDomain.CurrentDomain.GetAssemblies().Select(a => a.GetName().Name)));
            pluginHost.CallEach<ITestPlugin>(testPlugin => testPlugin.DoSomething());
            //Console.ReadLine();
        }
    }
