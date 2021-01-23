    var tasks = new Task[commands.Count];
    for (int i = 0; i < commands.Count; i++)
    {
        tasks[i] = Task.Factory.StartNew(() => {
           string strCmdText = commands[i];
           var process = System.Diagnostics.Process.Start("CMD.exe", strCmdText);
           process.WaitForExit();
        });
    }
    
    Task.WaitAll(tasks);
