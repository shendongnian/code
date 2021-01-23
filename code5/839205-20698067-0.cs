    string connectionString = 
            "Data Source=S;Initial Catalog=Gits_Retailer;User ID=sa;Password=sa";
        
        SqlConnection SqlConn = new SqlConnection(connectionString);
        SqlConn.Open();
        
        DataSet ds = new DataSet();
        for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
        {
            SqlDataAdapter da = 
                new SqlDataAdapter("INSERT INTO unit_master VALUES('" 
                                    + dataGridView1.Rows[i].Cells[0].Value 
                                    + "')", SqlConn);    
            da.Fill(ds);                                
        }
    SqlConn.Close()
