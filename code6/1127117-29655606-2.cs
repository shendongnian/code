    foreach (db_element in db)
    {
        foreach (list_element in list)
        {
            list_element.property = ...;
        }
    }
Assuming 3 elements in db and 5 elements in list there would be 15 assignments (3 x 5 = 15), instead of just 3 as you may have intended.
Instead, this is how you can implement a condition for matching the appropriate element from list
    foreach (db_element in db)
    {
        foreach (list_element in list)
        {
            if (list_element.ItemId == db_element.ItemId &&
                list_element.ListId == db_element.ListId)
            {
                 list_element.property = ...;
            }
            else
            {
                 // wrong one! skip.
            }
        }
    }
