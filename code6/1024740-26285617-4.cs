    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Console.WriteLine("Mouse Hook");
            // our UI thread here
            var t = new Thread(() =>
            {
                using (new MouseRightClickDisable())
                    Application.Run();
            });
            t.Start();
            //some console task here!
            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine("Console Task {0}",i);
                Thread.Sleep(100);
            }
            Console.WriteLine("press any key to terminate the application...");
            Console.ReadKey();
            Application.Exit();
        }
    }
