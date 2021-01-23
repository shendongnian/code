        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("FirstColumn1", Type.GetType("System.String"));
            dt.Columns.Add("FirstColumn2", Type.GetType("System.String"));
            dt.Columns.Add("FirstColumn3", Type.GetType("System.String"));
            dt.Columns.Add("FirstColumn4", Type.GetType("System.String"));
            dt.Columns.Add("FirstColumn5", Type.GetType("System.String"));
            dt.Columns.Add("FirstColumn6", Type.GetType("System.String"));
            string result = GetLastColumnn(dt);
        }
        private string GetLastColumnn(DataTable dt)
        {
            string str = dt.Columns[dt.Columns.Count-1].ColumnName;
            return str;
        }
