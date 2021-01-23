    string newItem = "OHIO";
    if (chkboxlist.Items.Cast<ListItem>().Any(r => r.Text == newItem))
    {
        //Already exists
    }
    else
    {
        chkboxlist.Items.Add(newItem);
    }
