    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("**Process Redirector for PC**");
            var client = new RedirectClient();
            var interceptArgs = args
                .Aggregate(string.Empty, (current, a) => current + (string.Format("\"{0}\"", a)));
            var process=RedirectProcess.StartGrab("PC-real.exe", s =>
            {
                Console.WriteLine(s);
                client.Send(s);
            },
                interceptArgs);
            client.Id = process.Id;
            process.WaitForExit();
            client.Dispose();
        }
    }
