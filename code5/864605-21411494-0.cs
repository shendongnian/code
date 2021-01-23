    static class Program
    {
        [STAThread]
        private static void Main()
        {
            // Run form in separate thread
            var runner = new FormRunner();
            var thread = new Thread(runner.Start) {IsBackground = false};
            thread.Start();
            // Process console input
            while (true)
            {
                string a = Console.ReadLine();
                runner.Display(a);
                if (a.Equals("exit")) break;
            }
            runner.Stop();
        }
    }
