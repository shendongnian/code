    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater repImages = (Repeater)e.Item.FindControl("repImgs"); 
            string amenText = ((DataRowView)e.Item.DataItem).Row.ItemArray[7].ToString();
            DirectoryInfo folderBr = new DirectoryInfo(Server.MapPath("~/uploads/images/Blog/") + amenText);
            
            if (folderBr.Exists)
            {
                repImages.DataSource = folderBr.GetFiles("thumb*.*");      // Bind room images to child repeater  
                repImages.DataBind();
    
                if (repImages.Items.Count == 0)
                {
                    PlaceHolder placeholder1 = (PlaceHolder)e.Item.FindControl("PlaceHolder1");
                    placeholder1.Visible = true;
                }
    
                // Iterate thru each item of your child repeate control.
                foreach (RepeaterItem repeaterItem in repImages.Items)
                {
                    if (repeaterItem.ItemType == ListItemType.Item ||
                        repeaterItem.ItemType == ListItemType.AlternatingItem)
                    {
                        ((HtmlImage)(repeaterItem.FindControl("imgId"))).Alt = amenText; // Assume amenText is the title of your post
                    }
    
                }
            }
            else
            {
                PlaceHolder placeholder1 = (PlaceHolder)e.Item.FindControl("PlaceHolder1");
                placeholder1.Visible = true;
            }
        }
    }
