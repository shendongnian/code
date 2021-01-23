    public List<string> ExecutePSExec(string hostname)
    {
        List<string> recordNames = new List<string>();
        string command = @"\\path\to\psexec.exe /accepteula \\" + hostname + ". exe-to-run-remotely";
        try
        {
            string location = AppDomain.CurrentDirectory.BaseDirectory;
            string cmdWithFileOutput = string.Format("{0} >{1}temp.log", command, location);
            procStartInfo.UseShellExecute = true;
            procStartInfo.CreateNoWindow = true;
            procStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Process proc = new Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
            proc.WaitForExit();
            // Read file contents, manipulate data and then delete temp file here
        }
        catch (Exception e)
        {
            Console.WriteLine("Failure to run psexec: {0}", e.Message);
        }
        return recordNames;
    }
