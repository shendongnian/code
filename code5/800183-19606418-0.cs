    public static void Main()
        {
            ProcessStartInfo proc = new ProcessStartInfo();
            proc.FileName = @"C:\Users\mehmetcan\Desktop\adt-bundle-windows-x86-20130917\sdk\platform-tools\adb.exe";
             proc.Arguments = @"devices";
    
            Process p = Process.Start(proc);
            p.OutputDataReceived += (sender, e) => Console.WriteLine(e.Data);
            p.BeginOutputReadLine();
            p.Start();
            p.WaitForExit();
            Thread.Sleep(5000);
        }
