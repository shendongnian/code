    void R1_ItemDataBound(Object Sender, RepeaterItemEventArgs e) {
          // This event is raised for the header, the footer, separators, and items.
          // Execute the following logic for Items and Alternating Items.
          if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
             if (((Evaluation)e.Item.DataItem).Rating == "Good") {
                ((Label)e.Item.FindControl("RatingLabel")).Text= "<b>***Good***</b>";
             }
          }
       } 
