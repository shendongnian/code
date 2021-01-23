    List<string> names = new List<string>(); // This will hold text for matched items found
    foreach (ListItem item in tempListName)
    {
        foreach (string value in tempList)
        {
            if (value == item.Value)
            {
                names.Add(item.Text);
            }
        }
    }
