    Process proc = new Process();
    
    proc.StartInfo.FileName = "regedit.exe";
    proc.StartInfo.Arguments = "/s";
    proc.StartInfo.UseShellExecute = false;
    proc.StartInfo.RedirectStandardInput = true;
    proc.Start();
    StreamWriter stdin = myProcess.StandardInput;
    
    var assembly = Assembly.GetExecutingAssembly();
    var resourceName = "<regfile>";
    
    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
    using (StreamReader reader = new StreamReader(stream))
    {
        stdin.Write(reader.ReadToEnd());
    }
