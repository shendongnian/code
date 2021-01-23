    ProcessStartInfo psi = new ProcessStartInfo();
    psi.FileName = Task.EXEFilename;
    psi.WorkingDirectory = Path.GetDirectoryName(Data.EXEFilename);
    var proc = Process.Start(psi);
    Debug.WriteLine(proc.Id);
