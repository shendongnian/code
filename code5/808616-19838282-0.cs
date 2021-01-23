    void Repeater1_ItemDataBound(Object Sender, RepeaterItemEventArgs e) 
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
        {
            DropDownList DropDownListcontrol = e.Item.FindControl("DropDownList4") as DropDownList;
            //Do other tasks
        }
    }    
