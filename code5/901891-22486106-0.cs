    DateTime targetTime = DateTime.Now;
    pro.StandardInput.Write(temp + Environment.NewLine);
    pro.StandardInput.Write(instruction + Environment.NewLine);
    pro.StandardInput.Close();
    Process[] fdtdProcs = Process.GetProcessesByName("FTDT");
    int pid = fdtdProcs
                .OrderBy(x => (x.StartTime - targetTime).Duration()).First().Id;
