    void PopulateApplications()
            {
                dataGridView1.Rows.Clear(); 
                dataGridView1.Height=0;
                dataGridView1.Height += dataGridView1.ColumnHeadersHeight;           
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
                        dataGridView1.Height+=22;
                    }
                }
            }
