    using (var conn = new OracleConnection(strConn2))
    {
        using (var cmd = conn.CreateCommand())
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "VN_PKG.vb_new_serial";        
    
            OracleParameter myReturn = new OracleParameter("myReturn", OracleDbType.Int32, ParameterDirection.ReturnValue); 
            cmd.Parameters.Add(myReturn);
    
            conn.Open();    
            cmd.ExecuteNonQuery();
            MessageBox.Show(myReturn.Value.ToString());
         }
    }
