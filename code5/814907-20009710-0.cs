    private static void ThirtyMinuteUpload(DateTime today)
    {
        using (var cn = new SqlConnection(connString))
        using (var cmd = new SqlCommand("mySP", cn))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            using (var rdr = cmd.ExecuteReader())
            using (var writer = new StreamWriter("exlcusion_" + today.ToString("MMddyyHHmmss") + ".csv"))
            {
                 while (rdr.Read())
                 {
                     writer.WriteLine(rdr.GetString(0));
                 }
            }
        }
    }
