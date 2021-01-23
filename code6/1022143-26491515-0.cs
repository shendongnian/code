    public class RedirectProcess
    {
        public static Process StartRedirected(string filename,string args="")
        {
            var process = Process.Start(new ProcessStartInfo
            {
                Arguments=args,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                FileName = filename
            });
            process.OutputDataReceived += (s,e)=>Console.WriteLine(e.Data);
            process.BeginOutputReadLine();
            return process;
        }
        public static Process StartGrab(string filename, Action<string> dataHandle, string args="" )
        {
            var process = Process.Start(new ProcessStartInfo
            {
                Arguments = args,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                FileName = filename
            });
            process.OutputDataReceived += (s, e) => dataHandle(e.Data);
            process.BeginOutputReadLine();
            return process;
        }
    }
