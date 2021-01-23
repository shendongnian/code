    var tasks = commands.Select(strCmdText => Task.Factory.StartNew(() => {
        var process = System.Diagnostics.Process.Start("CMD.exe", strCmdText);
        process.WaitForExit();
    })).ToArray();
    Task.WaitAll(tasks);
