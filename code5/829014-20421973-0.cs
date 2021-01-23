    // verify if the process has exited
    if(this.process != null && this.process.HasExited)
    {
            Process p = new Process();
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "chrome.exe";
            p.StartInfo = info;
            info.Arguments = "https://www.google.lk";
            p.Start();
            // save the process in a variable
            this.process = p;
    }
