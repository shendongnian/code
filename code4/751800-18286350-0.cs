    proc.Start();
    while (!proc.StandardOutput.EndOfStream) {
        string line = proc.StandardOutput.ReadLine();
        outputBuilder.Append(line);
        outputBuilder.Append(Environment.NewLine);
        this.SetText(outputBuilder.ToString());
    }
