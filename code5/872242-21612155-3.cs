    var usersAndBosses = new List<Tuple<string, string>>();
    while (reader.Read())
    {
        string username = reader.GetString(0); // column index 0
        string bossname = reader.GetString(1); // column index 1
        usersAndBosses.Add(Tuple.Create(username, bossname));
    }
