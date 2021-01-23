    async void Test()
    {
        await Ping("www.google.com");
    }
---
    Task Ping(string host)
    {
        var tcs = new TaskCompletionSource<object>();
                        
        ProcessStartInfo psi = new ProcessStartInfo();
        psi.FileName = "ping.exe";
        psi.UseShellExecute = false;
        psi.RedirectStandardOutput = true;
        psi.Arguments = host;
            
        var proc = Process.Start(psi);
        proc.OutputDataReceived += (s, e) => {
                Action action = () => textBox1.Text += e.Data + Environment.NewLine;
                this.Invoke(action);
            };
                
        proc.Exited += (s, e) => tcs.SetResult(null);
        proc.EnableRaisingEvents = true;
        proc.BeginOutputReadLine();
        return tcs.Task;
    }
