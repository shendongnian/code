    try
    {
        cmd.ExecuteNonQuery();
    }
    catch (Exception ex)
    {
        var sql = "select top (1) [definition] " +
                  "from sys.sql_modules m " +
                  "join sys.objects o " +
                  "on m.object_id = o.object_id " +
                  "where o.name = 'My_StoredProcedure' ";
        
        var qry = new SqlCommand(sql, conn);
        var rdr = qry.ExecuteReader(CommandBehavior.SingleRow);
        string definition = null;
        while(rdr .Read())
        {
            definition = rdr["definition"].ToString();
        }
    }
