    void Item_Bound(Object sender, DataListItemEventArgs e)
    {
         if (e.Item.ItemType == ListItemType.Item || 
             e.Item.ItemType == ListItemType.AlternatingItem)
         {
            ImageButton imagebutton = (ImageButton )e.Item.FindControl("imagebutton");
            if(OnlineStatus)
               imagebutton.ImageURL = path1;
            else
               imagebutton.ImageURL = path2;  
         }
    }
