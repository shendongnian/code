    List<string> legals = new List<string>();
    if(!reader.IsDbNull(reader.GetOrdinal("legal1")))
        legals.Add(reader["legal1"].ToString());
    if(!reader.IsDbNull(reader.GetOrdinal("legal2")))
        legals.Add(reader["legal2"].ToString());
    if(!reader.IsDbNull(reader.GetOrdinal("legal3")))
        legals.Add(reader["legal3"].ToString());
    LegalDesc = string.Join(" ", legals); 
