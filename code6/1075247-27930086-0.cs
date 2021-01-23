    // Not needed
    // ad.Fill(dt);
    NpgsqlDataReader dRead = com.ExecuteReader();
    while (dRead.Read())
    {
       for(int i = 0; i < dRead.FieldCount; i++)
           Console.Write("{0} \t \n", dRead[i].ToString());
    }
