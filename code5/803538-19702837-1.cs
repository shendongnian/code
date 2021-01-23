    Dictionary<int, int> results = new Dictionary<int, int>();
    
    try
    {
        Dictionary<int, int> temp = new Dictionary<int, int>();
        using (SqlConnection sqlConn = new SqlConnection("some connection string"))
        {
            using (SqlDataReader sqlDR = sqlCmd.ExecuteReader())
            {
                while (sqlDR.Read())
                {
                    temp.Add((int)sqlDR["keyColumnName"], (int)sqlDR["valueColumnName"]);
                }
            }
        }
        results = temp;
    }
    catch { }
    
    return results;
