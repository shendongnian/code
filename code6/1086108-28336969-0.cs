    void _bw_DoWork(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker worker = (BackgroundWorker)sender;
        string filepath = Path.Combine(Path.GetTempPath(), "Silverlight.exe");
        Process p = new Process();
        p.StartInfo.FileName = filepath;
        p.StartInfo.Arguments = string.Format(" /q  /i \"{0}\" ALLUSERS=1", filepath);
        p.StartInfo.Verb = "runas";
        p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        p.StartInfo.RedirectStandardOutput = true;
        p.StartInfo.UseShellExecute = false;
        p.Start();
        string line;
        while ((line = p.StandardOutput.ReadLine()) != null)
        {
            worker.ReportProgress(ConvertStdoutToProgress(line));
        }
    }
