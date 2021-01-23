    List<string> result = new List<string>();
    foreach (ListItem li in ListBox1.Items)
    {
        if (li.Selected == true)
        {
            // get the value of the item in your loop
            result.Add(li.Value);
        }
    }
