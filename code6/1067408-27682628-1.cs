    List<Task> tasks = new List<Task>();            
    foreach (string script in scriptList)
    {
        string tmpScript = script;
        tasks.Add(Task.Run(delegate {
            ProcessStartInfo myProcess = new ProcessStartInfo();
            myProcess.FileName = accoreconsolePath;
            myProcess.Arguments = "/s \"" + tmpScript + "\"";
            myProcess.CreateNoWindow = true;
            Process.Start(myProcess).WaitForExit();
            File.Delete(tmpScript);
        }));
    }
    Task.WaitAll(tasks.ToArray());
