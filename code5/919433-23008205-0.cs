        protected void GetProperties()
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand("AgentGetPropertiesToFinish", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            conn.Open();
            adp.Fill(table);
            _propertyGridView.DataSource = table.Rows.Cast<DataRow>().OrderBy(a => a.Field<string>("PostCode"));
            _propertyGridView.DataBind();
        }
