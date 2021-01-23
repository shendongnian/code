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
            IDictionaryEnumerator enumerator = ht.GetEnumerator();
            DataRow row = null;
            while (enumerator.MoveNext())
            {
                int index = (int)enumerator.Key; 
                string value = (string)enumerator.Value;
                row = dt.NewRow();
                row["col1"] = index;
                row["col2"] = value;
                dt.Rows.Add(row);
            }
            dgv.DataSource = ds.Tables[0];
        }
