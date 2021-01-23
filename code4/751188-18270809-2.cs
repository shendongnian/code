    static void Main(string[] args)
    {
        string openexe= @"C:\Users\marek\Documents\Visual Studio 2012\Projects\tours\tours\bin\Debug\netpokl.exe";
        var proc = new Process();
        proc.StartInfo = new ProcessStartInfo(openexe);
        proc.EnableRaisingEvents = true;
        proc.Exited += new EventHandler(proc_Exited);
        proc.Start();
    }
    static void proc_Exited(object sender, EventArgs e)
    {
        // the process has exited...
    }
