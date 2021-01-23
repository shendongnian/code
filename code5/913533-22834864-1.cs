    void Item_Bound(Object sender, DataListItemEventArgs e)
    {
         if (e.Item.ItemType == ListItemType.Item || 
             e.Item.ItemType == ListItemType.AlternatingItem)
         {
            ImageButton imagebutton = (ImageButton )e.Item.FindControl("imagebutton");
            bool onlineStatus = bool.Parse(DataBinder.Eval(Container.DataItem, "OnlineStatusDbColumn").ToString());
            if(onlineStatus) 
               imagebutton.ImageURL = path1;
            else
               imagebutton.ImageURL = path2;  
         }
    }
