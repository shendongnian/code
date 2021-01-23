    class Program
    {
        static void Main(string[] args)
        {
            Process process = new Process();
            process.StartInfo.FileName = "SimpleStderrWriter.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardInput = true;
            process.Start();
            Thread thread = new Thread(() =>
            {
                int cch;
                char[] rgch = new char[1];
                Console.WriteLine("Reading stderr from process");
                while ((cch = process.StandardError.Read(rgch, 0, rgch.Length)) > 0)
                {
                    Console.Write(new string(rgch, 0, cch));
                }
                Console.WriteLine();
                Console.WriteLine("Process exited");
            });
            Console.WriteLine("Press Enter to terminate process");
            thread.Start();
            Console.ReadLine();
            process.StandardInput.WriteLine();
            thread.Join();
        }
    }
