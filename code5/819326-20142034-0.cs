    using (SqlConnection cnn = new SqlConnection("Data Source=INBDQ2WK2LBCD2S\\SQLEXPRESS;Initial Catalog=MCAS;Integrated Security=SSPI"))
    {
        cnn.Open();
        SqlDataAdapter da = new SqlDataAdapter("select top(100) x from Table4 order by Id desc", cnn);
        DataSet ds = new DataSet();
        da.Fill(ds, "Table4");
        cnn.Close();
        List<String> xValues = new List<String>();
    
        foreach (DataRow row in ds.Tables["Table4"].Rows)
        {
            xValues.Add(row["x"].ToString());
        }
    }
