    var process = Process.GetProcessesByName("notepad").FirstOrDefault();
    if (process == null)
    {
        MessageBox.Show("process is not running");
    }
    else
    {
        process.EnableRaisingEvents = true;
        process.Exited += (sender, args) =>
            {
                MessageBox.Show("process exited");
            };
    }
