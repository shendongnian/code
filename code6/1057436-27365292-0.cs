     if (e.Item.ItemType == ListItemType.Item || 
         e.Item.ItemType == ListItemType.AlternatingItem)
     {
        Label CustomerTypeLabel = (Label)e.Item.FindControl("Label1");
        DataRowView drv= ((DataRowView)e.Item.DataItem).ToString();
        string CustomerType = drv.Row["CustomerType"].ToString();
        switch(CustomerType){
        case "R":
        case "P":
        case "Y":
              CustomerTypeLabel.Font.Bold = true;
              break;
        
        }
     }
