    private void Test(){
        KillProcess("notepad");
    }
    private void KillProcess(string processName) {
        Process[] appProcesses = Process.GetProcessesByName(processName);
        if(appProcesses.Length == 0)
            return;
        // Kill and wait for app to exit
        appProcesses[0].Kill();
        appProcesses[0].WaitForExit();
    }
