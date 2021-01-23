    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<string> GetClientNames(string prefix)
    {
        List<string> clients = new List<string>();
        using (SqlCeConnection conn = new SqlCeConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlCeCommand cmd = new SqlCeCommand())
            {
                cmd.CommandText = "SELECT [Name], [ID] FROM [Current] WHERE " + "[Name] LIKE " + "'" + prefix + "%'";
                cmd.Connection = conn;
                conn.Open();
                SqlCeDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    clients.Add(string.Format("{0}-{1}", sdr["Name"], sdr["ID"]));
                }
    
                conn.Close();
            }
            return clients;
        }
    }
