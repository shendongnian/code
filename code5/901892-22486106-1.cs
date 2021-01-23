    var pidsBefore = Process.GetProcessesByName("FTDT").Select(x => x.Id).ToList();
    pro.StandardInput.Write(temp + Environment.NewLine);
    pro.StandardInput.Write(instruction + Environment.NewLine);
    pro.StandardInput.Close();
    var pidsAfter = Process.GetProcessesByName("FTDT")
                           .Select(x => x.Id)
                           .Except(pidsBefore);
    int pid = pidsAfter.Single();
