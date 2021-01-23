    while (rdr.Read())
    {
    	email = rdr.GetString(0);
        if (rdr.GetString().Length() > 29)
        {
            string acctno = rdr.GetString().Substring(19, 10);
            // do something with acctno 
        }
    }
