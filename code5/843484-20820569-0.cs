      void Item_Bound(Object sender, DataListItemEventArgs e)
      {
         if (e.Item.ItemType == ListItemType.Item || 
             e.Item.ItemType == ListItemType.AlternatingItem)
         {
            // You can check for null here using e.Item.DataItem
            
            Hyperlink NameHyperLink = (HyperLink)e.Item.FindControl("NameHyperLink");
            
            NamedHyperLink.NavigateUrl = //Your code goes here..
         }
      }
