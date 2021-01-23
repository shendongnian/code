    class Program
    {
        static void Main()
        {
            var host = new JobHost();
            host.Call(typeof(Startup).GetMethod("Start"));
            host.RunAndBlock();
        }
    }
