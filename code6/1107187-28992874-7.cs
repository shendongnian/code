    protected void rptr_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            var orderItem = (DataRowView)e.Item.DataItem;
            Literal litCustomerName = (Literal)e.Item.FindControl("litCustomerName");
            Literal litName = (Literal)e.Item.FindControl("litName");
            Literal litEventType= (Literal)e.Item.FindControl("litEventType");
            Literal litEventDate = (Literal)e.Item.FindControl("litEventDate");
            Label lblStatus = (Label)e.Item.FindControl("lblStatus");
            
            // set the row data e.g.
            litCustomerName.Text = orderItem["CustomerName"].ToString();         
            switch(orderItem["EventStatus"].ToString())
            {
                case "accepted":
                   lblStatus.CssClass = "label label-accepted";
                   break;
                case "rejected":
                   lblStatus.CssClass = "label label-rejected";
                   break;
               // etc...
            }
         } 
     }
