Code
    public override void Install(IDictionary stateSaver)
    {
       base.Install(stateSaver);
    
       Process process = new Process();
       ProcessStartInfo info = new ProcessStartInfo();
       process.StartInfo = info;
    
       info.FileName = Path.Combine(this.Context.Parameters["targetdir"], "ConsoleApp.exe");
       info.UseShellExecute = false;
    
       process.Start();
    
    }
