        SqlConnection conn = new SqlConnection("connectionString");
        SqlCommand cmd = new SqlCommand("Select sum(stat_amount) as sumDebt from PostedVoucher where stat_flag ='D' and stat_leger =@stat_leger and branch=@branch and stat_date between @from and @to UNION Select sum(stat_amount) as sumcredit from PostedVoucher where stat_flag ='C' and stat_leger =@stat_leger and branch=@branch  and stat_date between @from and @to", conn);
        cmd.Parameters.AddWithValue("@stat_leger", ddlACCcode.SelectedValue);
        cmd.Parameters.AddWithValue("@branch", DDLBranch.SelectedValue);
        cmd.Parameters.AddWithValue("@from", db.getDate(txtFrom.Text));
        cmd.Parameters.AddWithValue("@to", db.getDate(txtTo.Text));
        conn.Open();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataSet dataSet = new DataSet();
        adapter.Fill(dataSet);       
        
        
        DataTable tbl1 = dataSet.Tables[0];
        DataTable tbl2 = dataSet.Tables[1];
        tbl1.Columns.Add("sumcredit");
        for (int i = 0; i < tbl2.Rows.Count; i++)
        {
            DataRow dr = tbl2.Rows[i];
            DataRow dr1 = tbl1.Rows[i];
            foreach (DataColumn v_Column in dr.Table.Columns)
            {
                if (dr1.Table.Columns.Contains("sumcredit"))
                {
                    dr1["sumcredit"] = dr["sumcredit"];
                }
            }
        }
