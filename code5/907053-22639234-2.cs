    pProcess.StartInfo.RedirectStandardOutput = true;
    pProcess.EnableRaisingEvents = true;  // Enable events
    pProcess.OutputDataReceived += outputRedirection; // hook up
    pProcess.Start();
    pProcess.BeginOutputReadLine();  // use async BeginOutputReadLine
    pProcess.WaitForExit();
