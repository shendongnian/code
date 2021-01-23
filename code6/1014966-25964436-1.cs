    for(int x = 0; x < combobox.Items.Count; x++)
    {
        string item = combobox.Items[x].ToString();
        if(item.Length > 17)
            combobox.Items[x] = item.Substring(0,17) + "...";
    }
