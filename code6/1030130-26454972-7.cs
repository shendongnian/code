        private void btnLoadAndBind_Click(object sender, EventArgs e)
        {
            this.FetchData(this.ds.Tables["Table1"]);
            this.AddSelectedColumn(this.ds.Tables["Table1"]);
            this.bindingSource1.Filter = "IsSelected = false";
            this.bindingSource2.Filter = "IsSelected = true";
        }
        private void FetchData(DataTable dataTable)
        {
            string CS = "your connectionstring";
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    con.Open();
                    var sqlcmd = new SqlCommand("SELECT Name FROM sometable", con);
                    sqlcmd.CommandType = CommandType.Text;
                    da.SelectCommand = sqlcmd;
                    da.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("exception raised");
                    throw ex;
                }
            }
        }
        private void AddSelectedColumn(DataTable suppliersDataTable)
        {
            var dc = new DataColumn("IsSelected", typeof(bool));
            suppliersDataTable.Columns.Add(dc);
            foreach (DataRow dr in suppliersDataTable.Rows)
            {
                dr["IsSelected"] = false;
            }
        }    
