    var psi = new ProcessStartInfo
    {
        FileName = "/bin/bash",
        UseShellExecute = false,
        RedirectStandardOutput = true,
        Arguments = string.Format("-c \"sudo {0} {1} {2}\"", "/path/to/script", "arg1", arg2)
    };
    using (var p = Process.Start(psi))
    {
        if (p != null)
        {
            var strOutput = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
        }
    }
