    protected void myRepeater_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (e.CommandName == "CHANGE_COLOR")
                {
                    LinkButton linkButton = (LinkButton)e.Item.FindControl("myLinkButton");
                    if (linkButton.ForeColor != System.Drawing.Color.Red)
                    {
                        linkButton.ForeColor = System.Drawing.Color.FromName("Red");
                        listData[e.Item.ItemIndex] = "Red"; //This is the key! This will prevent your color reset, as we save them inside ViewState
                    }
                    else
                    {
                        linkButton.ForeColor = System.Drawing.Color.FromName("Blue");
                        listData[e.Item.ItemIndex] = "Blue";
                    }
                }
            }
        }
