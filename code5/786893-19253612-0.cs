        private void CreateDataTable()
        {
            System.Data.DataTable dt = new DataTable("MyTable");
            dt.Columns.Add("MyColumn", typeof (string));
            dt.Rows.Add("row of data");
        }
