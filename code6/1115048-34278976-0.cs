    class Program
    {
        private static void Main()
        {
            var host = new JobHost();
            host.Call(typeof(Program).GetMethod("Start"));
            host.RunAndBlock();
        }
        [NoAutomaticTrigger]
        public static void Start(TextWriter textWriter)
        {
            
        }
    }
