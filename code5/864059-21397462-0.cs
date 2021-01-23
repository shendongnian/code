    foreach (RepeaterItem item in Repeater1.Items)
                {
                    if (item.ItemType == ListItemType.AlternatingItem || item.ItemType == ListItemType.Item)
                    {
                        TextBox tb= (TextBox)item.FindControl("TextBox1");
                        lblDisplay.Text = tb.Text;
        
                        
        
                    }
                }
