    public Form1()
    {
        InitializeComponent();
        Hashtable ht = new Hashtable();
        ht[1] = "One";
        ht[2] = "Two";
        ht[3] = "Three";
        BindDataGridView(dataGridView1, ht);
    }
    public void BindDataGridView(DataGridView dgv, Hashtable ht)
    {
        DataSet ds = new DataSet();
        DataTable dt = ds.Tables.Add("test");
        //now build our table
        dt.Columns.Add("col1", typeof(int));
        dt.Columns.Add("col2", typeof(string));
        foreach (DictionaryEntry dictionaryEntry in ht)
        {
            int index = (int)dictionaryEntry.Key;
            string value = (string)dictionaryEntry.Value;
            DataRow row = dt.NewRow();
            row["col1"] = index;
            row["col2"] = value;
            dt.Rows.Add(row);
        }
        dgv.DataSource = ds.Tables[0];
    }
