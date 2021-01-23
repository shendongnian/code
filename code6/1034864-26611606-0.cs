    List<int> countList = new List<int>();
    string sql = @"SELECT COUNT(PRODUCT_TYPE_NO) AS NumberOfProducts
                   FROM dbo.PRODUCT
                   Where PRODUCT_TYPE_NO IN ({0});";
    string[] paramNames = PTNList.Select(
        (s, i) => "@type" + i.ToString()
    ).ToArray();
    string inClause = string.Join(",", paramNames);
    using (SqlCommand cmd = new SqlCommand(string.Format(sql, inClause)))
    {
        for (int i = 0; i < paramNames.Length; i++)
        {
            cmd.Parameters.AddWithValue(paramNames[i], PTNList[i]);
        }
        // con.Open(); // if not already open
        using (var rd = cmd.ExecuteReader())
        {
            while (rd.Read())
            {
                countList.Add(rd.GetInt32(0));
                // or simply: sw.WriteLine(rd.GetInt32(0));
            }
        }
    }
