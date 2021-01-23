        Process proc = new Process();
        proc.StartInfo = new ProcessStartInfo("d:\\batch.bat")
        {
            RedirectStandardOutput = true,
            UseShellExecute = false
        };
        bool updated = false;
        Timer waitTimer= new Timer(state =>
        {
            if (!updated)
            {
                proc.Kill();
                return;
            }
            updated = false;
        });
        waitTimer.Change(1000, 1000);
        proc.Start();
        while (! proc.StandardOutput.EndOfStream)
        {
            var line = proc.StandardOutput.ReadLine();
            updated = true;
            Console.WriteLine(line);
        }
