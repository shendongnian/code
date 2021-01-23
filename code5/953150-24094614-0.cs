    void PopulateApplications()
    {
        dataGridView1.Rows.Clear();
        foreach (Process p in Process.GetProcesses())
        {
            if (p.MainWindowTitle.Length > 1)
            {
                var icon = Icon.ExtractAssociatedIcon(p.MainModule.FileName);
                ima = icon.ToBitmap();
                ima = resizeImage(ima, new Size(25, 25));
                ima.Save(@"c:\temp\ima.jpg");
                String status = p.Responding ? "Running" : "Not Responding";
                dataGridView1.Rows.Add(ima, p.ProcessName, status);
            }
        }
        int totalRowSize = dataGridView1.Rows.Count * 22;
        int formHeight = this.Size.Height;
        if (totalRowSize > formHeight-30)
            this.Height = totalRowSize + 30;
    }
