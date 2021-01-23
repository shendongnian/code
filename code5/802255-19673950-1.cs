    IList<string> listNames = new List();
    //
    for (int i = 0; i < lines.Count; i++)
    {
        //
        var temp = columns[5].Split('|', '>');
        if (!listNames.Contains(temp[0]))
        {
            listNames.Add(temp[0]);
            items.Add(new Item() 
            { 
                //
            });
        }
    }
