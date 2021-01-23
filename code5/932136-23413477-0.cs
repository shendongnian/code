    class Program
    {
        private const string Kernel32_DllName = "kernel32.dll";
        [DllImport(Kernel32_DllName)]
        private static extern bool AllocConsole();
        static void Main(string[] args)
        {
            if (args[0] == "/")
            {
                AllocConsole();
                
                
                Console.WriteLine("Details");
                Console.ReadKey();
                //cases and such for your menu options
            }
