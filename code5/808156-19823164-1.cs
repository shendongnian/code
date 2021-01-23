    Process p = new Process();
    p.StartInfo.FileName = "pdflatex";
    p.StartInfo.Arguments = save.FileName;
    p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
    p.EnableRaisingEvents = true;
    p.Exited += (sender, arguments) =>
    {
        prg.Invoke(new Action(() => prg.Stop()));
        //TODO look at the process's status - display errors
    };
    prg.Start();
