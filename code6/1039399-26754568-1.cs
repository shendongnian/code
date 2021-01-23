       void repCategories_ItemDataBound(Object Sender, RepeaterItemEventArgs e) {
          if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
                ((LinkButton)e.Item.FindControl("lbMyLinkButton")).OnClientClick = "alert('hi');";
          }
       }    
