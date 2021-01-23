    private DataTable table = null;
    private void buttonLoad_Click(object sender, EventArgs e)
    {
        // TODO: Select the row count here and assign it to progressBar.Maximum
        progressBar.Visible = true;             
        System.Threading.Thread thread = 
          new System.Threading.Thread(new System.Threading.ThreadStart(loadTable));
        thread.Start();
        progressTimer.Enabled = true;
    }
    private void loadTable()
    {
        // Load your Table...
        this.table = new DataTable();
        SqlDataAdapter SDA = new SqlDataAdapter();
        SDA.Fill(table);
        setDataSource(table);
    }
    internal delegate void SetDataSourceDelegate(DataTable table);
    private void setDataSource(DataTable table)
    {
        // Invoke method if required:
        if (this.InvokeRequired)
        {
            this.Invoke(new SetDataSourceDelegate(setDataSource), table);
        }
        else
        {
            progressTimer.Enabled = false;
            dataGridView.DataSource = table;
            progressBar.Visible = false;
        }
    }
    private void progressTimer_Tick(object sender, EventArgs e)
    {
        if (this.table != null)
            progressBar.Value = this.table.Rows.Count;
    }
