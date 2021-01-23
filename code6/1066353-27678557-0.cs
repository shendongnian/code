    class Program
        {
            static void Main(string[] args)
            {
                ProcessStartInfo startinfo = new ProcessStartInfo();
                startinfo.FileName = @"D:\Plink0.57\plink-057.exe";
                startinfo.Arguments = "-ssh mahi@192.168.37.129  -pw mahi";
                Process process = new Process();
                process.StartInfo = startinfo;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardInput = true;
                process.Start();
                process.StandardInput.WriteLine("ls");
                process.WaitForExit();
                Console.ReadKey();
            }
        }
