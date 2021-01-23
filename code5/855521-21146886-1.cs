       var l = new List<string>();
       l.Add("2th");
       l.Add("3th");
    
       var cmd = new NpgsqlCommand("select * from book_editions where editions = any (@parameterlist)", conn);    
       
       cmd.Parameters.Add("@parameterlist", NpgsqlDbType.Array | NpgsqlDbType.VarChar).Value = l;
    
       var dr = cmd.ExecuteReader();
    
       while (dr.Read())
         Console.Write("{0} \n", dr[0].ToString());
    
       Console.ReadKey();
       conn.Close();
