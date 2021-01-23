    using System.Diagnostics;
    ...
    Process process = new Process();
    process.StartInfo.FileName = "yourexe.exe";
    process.Start();
    process.WaitForExit();// Waits here for the process to exit.
