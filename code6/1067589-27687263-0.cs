    protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType==ListViewItemType.DataItem)
            {
                if (YourCondition)
                {
                    Button hdn = (Button)e.Item.FindControl("hiddenButton");
                    hdn.Visible = false;
                }
            }
        }
