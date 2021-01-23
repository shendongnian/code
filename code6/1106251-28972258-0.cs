    internal class Program
    {
        private static void Main(string[] args)
        {
            //load the .exe assembly using reflection(just for testing)
            var currPlugin = LoadAssembly(Assembly.GetEntryAssembly().Location);
            Console.WriteLine(currPlugin.Name);
            currPlugin.OnExecute += currPlugin_OnExecute;
            currPlugin.Execute(10d, 20d);
        }
        private static void currPlugin_OnExecute(object sender, EventArgs e)
        {
            var plugin = (IPlugin) sender;
            Console.WriteLine("Event OnExecute triggered from DLL '{0}'", plugin.GetType().Assembly.FullName);
            Console.WriteLine("[{0}] Event OnExecute -> {1}", plugin.Name, plugin.GetLastResult);
        }
        private static IPlugin LoadAssembly(string assemblyPath)
        {
            string assembly = Path.GetFullPath(assemblyPath);
            Assembly ptrAssembly = Assembly.LoadFile(assembly);
            foreach (Type item in ptrAssembly.GetTypes())
            {
                if (!item.IsClass) continue;
                if (item.GetInterfaces().Contains(typeof (IPlugin)))
                {
                    return (IPlugin) Activator.CreateInstance(item);
                }
            }
            throw new Exception("Invalid DLL, Interface not found!");
        }
    }
    public interface IPlugin
    {
        string Name { get; }
        string GetDescription();
        double GetLastResult { get; }
        double Execute(double value1, double value2);
        event EventHandler OnExecute;
        void ExceptionTest(string input);
    }
    public class Sum : IPlugin
    {
        private double _lastResult = double.NaN;
        public string Name
        {
            get { return "Sum"; }
        }
        public string GetDescription()
        {
            return "Plugin description";
        }
        public double GetLastResult
        {
            get { return _lastResult; }
        }
        public double Execute(double value1, double value2)
        {
            _lastResult = value1 + value2;
            OnExecuteInvoke();
            return _lastResult;
        }
        public event EventHandler OnExecute;
        protected virtual void OnExecuteInvoke()
        {
            var handler = OnExecute;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
        public void ExceptionTest(string input)
        {
            throw new Exception(input);
        }
    }
