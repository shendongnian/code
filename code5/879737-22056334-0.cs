    class Program
    {
    static void Main(string[] args)
    {
        string[] myApps = { "notepad.exe", "calc.exe", "explorer.exe" };
        Thread w;
        ParameterizedThreadStart ts = new ParameterizedThreadStart(StartMyApp);
        foreach (var myApp in myApps)
        {
            w = new Thread(ts);
            w.Start(myApp);
            Thread.Sleep(1000);
        }
    }
    private static void StartMyApp(object myAppPath)
    {
        ProcessStartInfo myInfoProcess = new ProcessStartInfo();
        myInfoProcess.FileName = myAppPath.ToString();
        myInfoProcess.WindowStyle = ProcessWindowStyle.Minimized;
        Process myProcess = Process.Start(myInfoProcess);
        do
        {
            if (!myProcess.HasExited)
            {
                myProcess.Refresh(); // Refresh the current process property values.
                Console.WriteLine(myProcess.ProcessName+" RAM: "+(myProcess.WorkingSet64 / 1024 / 1024).ToString()+"\n");
                Thread.Sleep(1000);
            }
        }
        while (!myProcess.WaitForExit(1000)); 
    }
}
