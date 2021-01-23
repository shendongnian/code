    void PopulateApplications()
    {
        dataGridView1.Rows.Clear();
    
        DataGridViewImageColumn img = new DataGridViewImageColumn();
        img.HeaderText = "Icon";
        img.Name = "ImageCol";
        dataGridView1.Columns.Add(img);
        dataGridView1.Columns.Add("AppName", "Application Name");
        dataGridView1.Columns.Add("Status", "Status");
        foreach (Process p in Process.GetProcesses())
        {
            if (p.MainWindowTitle.Length > 1)
            {
                var icon = Icon.ExtractAssociatedIcon(p.MainModule.FileName);
                Image ima = icon.ToBitmap();
                (dataGridView1.Columns["ImageCol"] as DataGridViewImageColumn).Image = ima;
                String status = p.Responding ? "Running" : "Not Responding";
                dataGridView1.Rows.Add(icon, p.MainWindowTitle, status);
            }
        }
    }
