    var processes = new List<Process>();
    for (int i = 0; i < commands.Count; i++)
    {
        string strCmdText = commands[i];
        processes.Add(System.Diagnostics.Process.Start("CMD.exe", strCmdText));
    }
    
    foreach(var process in processes)
    {
        process.WaitForExit();
        process.Close();
    }
