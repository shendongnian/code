     void Repeater1_ItemDataBound(Object Sender, RepeaterItemEventArgs e) 
     {
          // Execute the following logic for Items and Alternating Items.
          if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
            Button btnSet = (Button)e.Item.FindControl("btnSet");
            if ( e.Item.DataItem["userType"].ToString() == "2")
            {
              btnSet.Text = "Set as Normal User";
            }
            else
            {
              btnSet.Text = "Set as Power User";
            }
          }
       }    
