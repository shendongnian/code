    private const int ROW_SIZE = 22;
    private int NumberOfRows;
    private int BaseFormHeight
    void PopulateApplications()
    {
        dataGridView1.Rows.Clear();
        
        foreach (Process p in Process.GetProcesses())
        {
            if (p.MainWindowTitle.Length > 1)
            {
                ... add a row to the data grid ...
            }
        }
        
        if(NumberOfRows != dataGridView1.Rows.Count)
        {
            NumberOfRows = dataGridView1.Rows.Count;
            this.Height = BaseFormHeight + (ROW_SIZE * NumberOfRows);
        }
    }
