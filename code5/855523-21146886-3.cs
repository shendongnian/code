       var cmd = new NpgsqlCommand("select array_to_string(column, ', '),othercolumn,othercolumn from table",connection);
       var l = new ArrayList();
       l.Add("2th");
       l.Add("3th");
       cmd.Parameters.Add(new NpgsqlParameter("parameterlist", NpgsqlDbType.Array | NpgsqlDbType.Varchar));      
       cmd.Parameters[0].Value = l.ToArray();
    
       var dr = cmd.ExecuteReader();
    
       while (dr.Read())
         Console.Write("{0} \n", dr[0].ToString());
    
       Console.ReadKey();
       conn.Close();
