    for (int i = 1; i <= 4; i++)
    {
        oListItem = oList.GetItemById(i);
        
        foreach (Field field in fieldcol)
        {
            context.Load(field);
            context.ExecuteQuery();
            val = oListItem[field.Title];
            if(val == null)
            {
                //Send e-mail
            }
        }
    }
