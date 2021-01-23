    System.Diagnostics.Process process = new System.Diagnostics.Process();
    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
    startInfo.FileName = "E:\\1\\2\\Abc.cmd";
    startInfo.WorkingDirectory = "E:\\1\\2\\";
    process.StartInfo = startInfo;
    process.Start();
