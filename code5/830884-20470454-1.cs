    Process[] processes = Process.GetProcesses();
    foreach(Process p in processes)
    {
        if(!String.IsNullOrEmpty(p.MainWindowTitle))
        {
            listBox1.Items.Add(p.MainWindowTitle);
        }
    }
