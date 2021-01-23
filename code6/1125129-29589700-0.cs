    protected void RepeaterImages_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
         RepeaterItem item = e.Item;
         if ((item.ItemType == ListItemType.Item) || (item.ItemType == ListItemType.AlternatingItem))
         {
             Imagebutton  Imagebutton2= (Imagebutton)item.FindControl("Imagebutton2");
             
             string trueanswer = Imagebutton.CommandArgument.ToString();
             string urlanswer = Imagebutton.CommandName.ToString();
     
             if (urlanswer == q_image)
             {
             }
             else
             {
                // Imagebutoon2 doesnt exist in current context why?
                Imagebutton2.BorderColor = Color.Red;
             }
        }
    }
