     exeProcess.WaitForExit(1 * 60 * 1000);
    
    if (!exeProcess.HasExited)
    {
        _log.Warn("External process has not completed after {0} minutes - trying to close main window", waitTimeMin);
        exeProcess.CloseMainWindow();
        System.Threading.Thread.Sleep(2000);
    }
    
    if (!exeProcess.HasExited)
    {
        _log.Warn("External process still has not completed - Killing process and waiting for it to exit...");
        exeProcess.Kill();
        exeProcess.WaitForExit();
    }
