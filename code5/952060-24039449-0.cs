    void PopulateApplications()
    {
        dataGridView1.Rows.Clear();
        
        foreach (Process p in Process.GetProcesses())
        {
            if (p.MainWindowTitle.Length > 1)
            {
                ...
                currentValue = dataGridView1.Rows.Count;
            }
        }
        
        if(currentValue != lastValue)
        {
            this.Height += (22 * (currentValue - lastValue));
            lastValue = currentValue;
        }
    }
