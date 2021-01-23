    Process pros = Process.Start(processStartInfo);
    pros.EnableRaisingEvents = true;
    pros.Exited += (object sender, EventArgs e) =>
    {
        int processId = pros.Id;
        // ...
    };
