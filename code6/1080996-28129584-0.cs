    using(var cmd = sqlConn.CreateCommand())
    { 
       cmd.CommandType = CommandType.StoredProcedure
       cmd.CommandText = "Insert";
 
       var tblName = cmd.Parameters.Add(new SqlParameter("table_name", SqlDbType.NVarChar));
       var attr_names = cmd.Parameters.Add(new SqlParameter("attr_names", SqlDbType.NVarChar));
       var attr_values = cmd.Parameters.Add(new SqlParameter("attr_values", SqlDbType.NVarChar));
       tblName.Value = "tableEmployee";
       attr_names.Value = "name,descr";
       attr_values.Value = "'abc','cde'";
       cmd.ExecuteNonQuery();
    }
