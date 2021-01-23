    Process[] processes = Process.GetProcesses();
    foreach(Process p in processes)
    {
        if(!String.EmptyOrNull(p.MainWindowTitle))
        {
            listBox1.Items.Add(p.MainWindowTitle);
        }
    }
