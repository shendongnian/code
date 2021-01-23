    private static void ThirtyMinuteUpload(DateTime today)
    {
        using (var cn = new SqlConnection(connString))
        using (var cmd = new SqlCommand("mySP", cn))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            using (var rdr = cmd.ExecuteReader())
            {
                if (!rdr.HasRows) return;
                var fileName = string.Format("{0}{1}exclusion_{2:MMddyyHHmmss}.csv",
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    Path.PathSeparator,
                    today);
                using (var writer = new StreamWriter(fileName))
                {
                    while (rdr.Read())
                    {
                        writer.WriteLine(rdr.GetString(0));
                    }
                }
            }
        }
    }
