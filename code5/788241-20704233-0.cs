        static void Main(string[] args)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "notepad.exe",
                UseShellExecute = true,
                RedirectStandardOutput = false
            };
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                Process.Start(startInfo);
            }).Start();
        }
