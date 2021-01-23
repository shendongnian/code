    Process process = new Process();
    process.StartInfo.FileName = "F:\abc.lnk";
    process.StartInfo.Arguments = "use \\\\computerName\\share password /user:UserName";
    process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
    process.StartInfo.UseShellExecute = false;
    process.Start();
    process.WaitForExit();
    process.Dispose();
