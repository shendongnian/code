    using(SqlConnection conn = new SqlConnection("<connection string here>")
    {
        string cmdString = "INSERT INTO AigsAuthorityLayer (lGid, LayerNo, lAuthority, IEditFlg ) VALUES(@lGid, @layerNo, @lAuthority, @lEditFlag)";
        using(SqlCommand cmd = new SqlCommand(cmdString, conn)
        {
    
            cmd.CommandType = System.Data.CommandType.Text;
    
            SqlParameterCollection p = cmd.Parameters;
    
            // Build a parameter for each of @lGid, @layerNo, @lAuthority, @lEditFlag
            SqlParameter p1 = p.AddWithValue("@lGid", GroupId);
            p1.SqlDbType = System.Data.SqlDbType.Int; // Int assumed here
    
            // Repeat for other parameters
            ...
    
            // Run query as needed
            cmd.ExecuteNonQuery(); // Or appropriate method
    
        }
    }
