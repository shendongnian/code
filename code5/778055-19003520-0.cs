    using (var process = new Process())
    {
        process.StartInfo.FileName = "notepad.exe";
        process.StartInfo.Arguments = "";
        process.Start();
        process.WaitForExit(1000);
        if (!process.HasExited)
            process.Kill();
    }
