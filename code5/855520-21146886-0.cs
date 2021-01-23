       var l = new List<string>();
       l.Add("2th");
       l.Add("3th");
    
       var p = new NpgsqlParameter("@parameterlist", NpgsqlTypes.NpgsqlDbType.Array | NpgsqlTypes.NpgsqlDbType.Text);
    
       var cmd = new NpgsqlCommand("select * from book_editions where editions = any (@parameterlist)", conn);    
       
       cmd.Parameters.AddWithValue("@parameterlist", "%" + l + "%");
    
       var dr = cmd.ExecuteReader();
    
       while (dr.Read())
         Console.Write("{0} \n", dr[0].ToString());
    
       Console.ReadKey();
       conn.Close();
