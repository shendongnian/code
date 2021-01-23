    DropDownList2.Items.Clear();
    DropDownList2.Items.Add("--Year--");
    foreach(var year in years)
    {    
        DropDownList2.Items.Add(year.ToString());
    }
