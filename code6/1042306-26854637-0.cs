    Items items = contacts.Items;
    for (int i = 1; i <= items.Count; i++)
    {
        ContactItem contact = items[i] as ContactItem;
        if (contact !=null)
        {
           ...
        }
    }
