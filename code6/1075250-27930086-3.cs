    ad.Fill(dt);
    // Not needed
    // NpgsqlDataReader dRead = com.ExecuteReader();
    foreach(DataRow row in dt.Rows)
    {
        for (int i = 0; i < dt.Columns.Count; i++)
        {
            Console.Write("{0} \t \n", row[i].ToString());
        }
    }
 
