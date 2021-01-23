    class Program
    {
        static void Main(string[] args)
        {
            ProcessStartInfo processStartInfo;
            processStartInfo = new ProcessStartInfo();
            processStartInfo.CreateNoWindow = true;
           
            // Redirect IO to allow us to read and write to it.
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.RedirectStandardInput = true;
            processStartInfo.UseShellExecute = false;
            processStartInfo.FileName = @"path\to\your\Echoer.exe";
            Process process = new Process();
            process.StartInfo = processStartInfo;
            process.Start();
            int counter = 0;
            while (counter < 10)
            {
                // Write to the process's standard input.
                process.StandardInput.WriteLine(counter.ToString());
                
                // Read from the process's standard output.
                var output = process.StandardOutput.ReadLine();
                Console.WriteLine("Hosted process said: " + output);
                counter++;
            }
            process.Kill();
            Console.WriteLine("Hit any key to exit.");
            Console.ReadKey();
        }
    }
