    DataTable dt;
    bool SilenceMode;
    private void Form1_Load(object sender, EventArgs e)
    {
        var dt = new DataTable();
        dt.Columns.Add("A");
        dt.Columns.Add("B");
        dt.ColumnChanged += ColChange;
        dataGridView1.DataSource = dt;
    }
    void ColChange(object sender, DataColumnChangeEventArgs e )
    {
        if (!SilenceMode)
        {
            SilenceMode = true;
            //******************
            //Here edit DataTable Without infinity loop
            string colNameToChange = e.Column.ColumnName == "A" ? "B" : "A";
            e.Row[colNameToChange] = e.ProposedValue;
            //******************
            SilenceMode = false;
        }
    }
