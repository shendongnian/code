    Dictionary<string,string> UserIDpw = new Dictionary<string,string>();
    while (myReader.Read())
    {
        UserIDpw.Add(myReader.GetString(0), myReader.GetString(1));
    }
