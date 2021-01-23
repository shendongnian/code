    private void button1_Click(object sender, EventArgs e)
    {
        Process proc = new Process();
        proc.StartInfo.FileName = "Calc";
        proc.StartInfo.UseShellExecute = false;
        proc.StartInfo.RedirectStandardInput = true;
        proc.EnableRaisingEvents = true;
        _process.Exited += (sender1, e1) => process.Dispose();
        proc.Start();
    }
