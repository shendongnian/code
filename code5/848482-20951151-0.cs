    var p = new Process
    {
        StartInfo =
        {
            FileName = "SomeApp.exe"
        }
    };
    p.Start();
    // Do whatever...
    if (!p.HasExited)
    {
        if (!p.CloseMainWindow())
            p.Kill();
    }
