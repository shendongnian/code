    async private void button1_Click(object sender, EventArgs e)
    {
        button1.Enabled = false;
        await RunProcessAsync("notepad.exe");
        button1.Enabled = true;
    }
    public Task RunProcessAsync(string processName)
    {
        TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.CreateNoWindow = false;
        startInfo.UseShellExecute = false;
        startInfo.FileName = processName;
        var proc = Process.Start(startInfo);
        proc.EnableRaisingEvents = true;
        proc.Exited += (s,e) => tcs.TrySetResult(null);
        
        return tcs.Task;
    }
