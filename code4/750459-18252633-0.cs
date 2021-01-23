    List<string> tempTextList = new List<string>();
    while (reader.Read())
    {
        string val = reader[0].ToString(),
            text = reader[1].ToString();
        if (tempList.Contains(val)) { tempTextList.Add(text); }
        temp_ListItem = new ListItem(text, val);
        tempListName.Add(temp_ListItem);
    }
