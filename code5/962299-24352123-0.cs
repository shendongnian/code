    BindingSource GetBS(bool addAll = false)
    {
        ......
        con.Open(); 
        cmd = new SqlCommand("uspPodruznicaSelect", con); 
        da.SelectCommand = cmd; 
        da.SelectCommand.CommandType = CommandType.StoredProcedure; 
        da.Fill(dbtable); 
    
        if(addAll)
        {
            DataRow dr = dbTable.NewRow();
            dr["ItemID"] = 0;
            dr["ItemData"] = "ALL";
            dbTable.Rows.InsertAt(dr, 0);
        }
    
        bsource.DataSource = dbtable; 
        con.Close(); 
        return bsource;
    }
