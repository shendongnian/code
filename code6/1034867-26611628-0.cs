    string query2 = @"SELECT COUNT(PRODUCT_TYPE_NO)
                        AS NumberOfProducts
                        FROM dbo.PRODUCT
                        Where PRODUCT_TYPE_NO = @ptn";
    using (var cmd2 = new SqlCommand(query2))
    {
        cmd2.Connection = con;
        cmd2.Parameters.Add("@ptn", SqlDbType.Varchar);
        foreach (var ptn in PTNList)
        {
            cmd2.Parameters["@ptn"].Value = ptn;
        
            Console.WriteLine("Running Query");
            using var (rdr = cmd2.ExecuteReader())
            {
              if (rdr.Read())
              {
                  sw.WriteLine(rdr["NumberOfProducts"] as string);
              }
            }
        }
   }
