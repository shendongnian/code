    await Exec(yourExe,parameters);
---
    Task Exec(string exe,string args)
    {
        var tcs = new TaskCompletionSource<object>();
        ProcessStartInfo psi = new ProcessStartInfo();
        psi.FileName = exe;
        psi.UseShellExecute = false;
        psi.RedirectStandardOutput = true;
        psi.Arguments = args;
        var proc = Process.Start(psi);
        proc.OutputDataReceived += (s, e) =>
        {
            Action action = () => textBox1.Text += e.Data + Environment.NewLine;
            this.Invoke(action);
        };
        proc.Exited += (s, e) => tcs.SetResult(null);
        proc.EnableRaisingEvents = true;
        proc.BeginOutputReadLine();
        return tcs.Task;
    }
