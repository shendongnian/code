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
                        dataGridView1.Rows.Add(ima,p.ProcessName, status);
                    }
                }
                firsttime += 1;
                if (firsttime == 1)
                {
                    NumberOfRows = dataGridView1.Rows.Count;
                }
                if (NumberOfRows != dataGridView1.Rows.Count)
                {
                    int diff = dataGridView1.Rows.Count - NumberOfRows;
                    this.Height = this.Height + (ROW_SIZE * diff);
                    NumberOfRows = dataGridView1.Rows.Count;
                }
    
            }
