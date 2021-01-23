    var info = new ProcessStartInfo("some.exe");
    info.CreateNoWindow = true;
    info.RedirectStandardOutput = true;
    info.UseShellExecute = false;
    using (var p = new Process())
    {
        p.StartInfo = info;
        var output = new StringBuilder();
        p.OutputDataReceived += (sender, eventArgs) =>
        {
            output.AppendLine(eventArgs.Data);
        };
        p.Start();
        p.BeginOutputReadLine();
        if (!p.WaitForExit(5000))
        {
            Console.WriteLine("Taking too long...");
            p.Kill();
            Console.WriteLine("Process killed, output :\n" + output);
        }
    }
