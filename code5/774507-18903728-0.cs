    class Program
    {
        static void Main(string[] args)
        {
            Process process1 = new Process();
            process1.StartInfo.FileName = "C:/Programming/Tournament/Player1.exe";
            process1.StartInfo.Arguments = "";
            process1.StartInfo.UseShellExecute = false;
            process1.StartInfo.RedirectStandardOutput = true;
            Process process2 = new Process();
            process2.StartInfo.FileName = "C:/Programming/Tournament/Player2.exe";
            process2.StartInfo.Arguments = "";
            process2.StartInfo.UseShellExecute = false;
            process2.StartInfo.RedirectStandardOutput = true;
            Thread T1 = new Thread(delegate() {
                Process(process1);
            });
            Thread T2= new Thread(delegate()
            {
                Process(process2);
            });
            T1.Start();
            T2.Start();
        }
        public static void Process(Process myProcess)
        {
            myProcess.Start();
            var result1 = myProcess.StandardOutput.ReadToEnd();
            myProcess.Close();
        }
    }
