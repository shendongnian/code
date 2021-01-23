    while (myReader.Read())
    {
        string sName = myReader.GetString(myReader.GetOrdinal("Title"));
        coll.Add(sName);
    }
