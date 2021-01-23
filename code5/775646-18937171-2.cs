    foreach (Process process in myProcesses)
    {
        process.EnableRaisingEvents = true;
        Process processInner = process;   // copy to inner variable
        processInner.Exited += (object sender, EventArgs e) =>
        {
            int processId = processInner.Id;   // always reference inner variable
            // ...
        };
    }
