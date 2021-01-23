    Process Process = Process.Start(ProcessInfo);
    while(!Process.HasExited)
       Process.WaitForExit(Timeout);
    
    //Finish.
    int ExitCode = Process.ExitCode;
    //Process.Close(); NO NEED AS PROCESS IS ALREADY EXITED
    return ExitCode;
