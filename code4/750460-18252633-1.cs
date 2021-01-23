    Dictionary<string, string> tempTextList = new Dictionary<string, string>();
    while (reader.Read())
    {
        string val = reader[0].ToString(),
            text = reader[1].ToString();
        if (tempList.Contains(val)) { tempTextList.Add(val, text); }
        temp_ListItem = new ListItem(text, val);
        tempListName.Add(temp_ListItem);
    }
