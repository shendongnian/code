    Process process = new Process();
    process.StartInfo.FileName = "<Folder>/<filename>.exe";
    process.StartInfo.Arguments = "your Parameters";
    process.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
    process.Start();
    process.WaitForExit();
    int code = process.ExitCode;
