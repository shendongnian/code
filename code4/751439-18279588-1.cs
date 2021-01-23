    foreach (ListItem li in GroupList.Items)
    {
        if (li.Selected)
        {
            EnterAGroup.Items.Add(new ListItem(li.Text, li.Value));
        }
    }
