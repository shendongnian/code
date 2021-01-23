    //Hi you could try this to build your process like this.
    public class Launcher
    {
        public Process CurrentProcess;
        public string result = null;
        public Process Start()
        {
            CurrentProcess = new Process
            {
                StartInfo =
                {
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    RedirectStandardInput = true,
                    WorkingDirectory = @"C:\",
                    FileName = Path.Combine(Environment.SystemDirectory, "cmd.exe")
                }
            };
            CurrentProcess.Start();
            return CurrentProcess;
        }
        //Start the process to get the output you want to add to your .txt file:
        private void writeOuput()
        {
            Currentprocess = new process();
            Start()
            CurrentProcess.StandardInput.WriteLine("Your CMD");
            CurrentProcess.StandardInput.Close();
            result = CurrentProcess.StandardOutput.ReadLine();
            CurrentProcess.StandardOutput.Close()
            //Then to put the result in a .txt file:
            System.IO.File.WriteAllText (@"C:\path.txt", result);
        }
    }
}
