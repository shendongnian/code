    firsttime = 0;
    dataGridView1.BackgroundColor = System.Drawing.Color.White;
    dataGridView1.Columns["Column2"].DefaultCellStyle.BackColor = System.Drawing.Color.LightGoldenrodYellow;
    dataGridView1.Columns["Column3"].DefaultCellStyle.BackColor = System.Drawing.Color.LightGoldenrodYellow;
    dataGridView1.AllowUserToAddRows = false;
    In the form1 load event:
    private void Form1_Load(object sender, EventArgs e)
            {
                _thisProcess = Process.GetCurrentProcess().Id;
                InitializeRefreshTimer();
                PopulateApplications();
            }
