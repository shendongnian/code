    if(rdbDate.Checked)
    {
        int numberOfRecords;
    
        using (SqlCommand cmd = new SqlCommand("select count(*) from TABLE where ORDER_DATE between @mindate and @maxdate", myConnection)
        {
            cmd.Parameters.AddWithValue("@mindate", dtFromDate.Value.Date);
            cmd.Parameters.AddWithValue("@maxdate", dtToDate.Value.Date);
    
            numberOfRecords = cmd.ExecuteScalar();
        }
        if(numberOfRecords >10000)
        {
            DialogResult msgresult = MessageBox.Show("Warning your query returned " 
                + t.Rows.Count + 
                " are you sure you want to continue?", 
                "Question", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);
    
            if (msgresult == DialogResult.No)
            {
                return;
            }
         }
        SqlDataAdapter adapter = new SqlDataAdapter("select * from TABLE where ORDER_DATE between @mindate and @maxdate", myConnection);
        adapter.SelectCommand.Parameters.AddWithValue("@mindate", dtFromDate.Value.Date);
        adapter.SelectCommand.Parameters.AddWithValue("@maxdate", dtToDate.Value.Date);
        DataTable t = new DataTable();
        adapter.Fill(t);
    }
