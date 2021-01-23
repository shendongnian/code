    class Program
    {
        static void Main( string[] args )
        {
            var currentAssembly = Assembly.GetExecutingAssembly();
            var localTypes = currentAssembly.GetTypes();
        }
    }
