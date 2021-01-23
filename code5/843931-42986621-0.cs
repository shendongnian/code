        foreach (var item in w)
        {
            if (Convert.ToInt32(e.CommandArgument) == item.ID)
            {
                item.Sort = 1;
            }
            else
            {
                item.Sort = null;
            }
            db.SubmitChanges();            
        }                   
