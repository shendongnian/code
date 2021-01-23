    internal class Program
    {
        private static void Main(string[] args)
        {
            //root
            if (args.Length == 0)
            {
                RedirectProcess.StartGrab("PA.exe", Console.WriteLine, "1");
                while (true)
                {
                    Console.WriteLine("Root, ID: {0},- Hello", Process.GetCurrentProcess().Id);
                    Thread.Sleep(1000);
                }
            }
            //child
            var count = int.Parse(args[0]);
            if (count < 3)  //maximum of 3 nested child process              
               RedirectProcess.StartRedirected("PA.exe", (count + 1).ToString());
            while (true)
            {
                Console.WriteLine("Child,Level: {0}, ID: {1},- Hello", count, Process.GetCurrentProcess().Id);
                Thread.Sleep(1000);
            }
        }
    }
