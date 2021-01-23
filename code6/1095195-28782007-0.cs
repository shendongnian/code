        SqlConnection conn = new SqlConnection(yourConnectionString);            
        SqlCommand cmd = new SqlCommand(your query,conn);
        SqlDataAdapter SDA = new SqlDataAdapter();
        DataTable dt = new DataTable(DataTableName);
        conn.Open();
        SDA.Fill(dt);
        conn.Close();
        String xml =  dt.Rows[0].ItemArray[0].ToString();
        return xml;
