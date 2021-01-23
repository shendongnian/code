    for (var i = 1; i < 13; i++)
    {
        var item = new ListItem
            {
                Text = i.ToString(),
                Value = i.ToString()
            };
        DropDownListMonth.Items.Add(item);
    }
