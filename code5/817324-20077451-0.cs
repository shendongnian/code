    var cd = RunProcessDirect("chkdsk.exe", "c:", false);
    protected ConsoleData RunProcessDirect(string processPath, string args, 
        bool isHidden)
    {
        Process process = SetupProcess(processPath, args, isHidden);
        process.Start();
        ConsoleData data = new ConsoleData();
        data.StandardOutput = process.StandardOutput.ReadToEnd();
        data.StandardError = process.StandardError.ReadToEnd();
        data.ExitCode = process.ExitCode;
        return data;
    }
    private Process SetupProcess(string processPath, string args, 
        bool isHidden)
    {
        Process process = new Process();
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.WindowStyle = isHidden 
            ? ProcessWindowStyle.Hidden 
            : ProcessWindowStyle.Normal;
        startInfo.CreateNoWindow = isHidden;
        startInfo.FileName = processPath;
        startInfo.Arguments = args;
        startInfo.RedirectStandardOutput = true;
        startInfo.RedirectStandardError = true;
        startInfo.UseShellExecute = false;
        process.StartInfo = startInfo;
        return process;
    }
    public class ConsoleData
    {
        public string StandardOutput { get; set; }
        public string StandardError { get; set; }
        public int ExitCode { get; set; }
    }
