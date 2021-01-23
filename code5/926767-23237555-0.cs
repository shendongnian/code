    public class Program
    {
        public static void Main(string[] args)
        {
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName               = "cmd.exe",
                    CreateNoWindow         = true,
                    UseShellExecute        = false,
                    RedirectStandardInput  = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError  = true
                }
            };
            proc.Start();
            new Thread(() => ReadOutputThread(proc.StandardOutput)).Start();
            new Thread(() => ReadOutputThread(proc.StandardError)).Start();
            while (true)
            {
                Console.Write(">> ");
                var line = Console.ReadLine();
                proc.StandardInput.WriteLine(line);
            }
        }
        private static void ReadOutputThread(StreamReader streamReader)
        {
            while (true)
            {
                var line = streamReader.ReadLine();
                Console.WriteLine(line);
            }
        }
    }
