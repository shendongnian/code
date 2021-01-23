    protected void Page_Load(object sender, EventArgs e)
            {
                pageList.DataSource = GetFlags();
                pageList.DataBind();
            }
    
            protected void pageList_ItemDataBound(object sender, RepeaterItemEventArgs e)
            {
                RepeaterItem item = e.Item;
                Repeater itemRepeater = (Repeater) e.Item.FindControl("itemRepeater");
    
                switch (item.ItemType)
                {
                    case ListItemType.Header:
                        break;
                    case ListItemType.Item:
                    case ListItemType.AlternatingItem:
                        if (itemRepeater != null)
                        {
                            var flagType = (item.DataItem as DataRowView).Row["Flag"].ToString();
                            DataTable repeaterData = GetData(flagType);
                            itemRepeater.DataSource = repeaterData;
                            itemRepeater.DataBind();
                        }
                        break;
                    case ListItemType.Footer:
                        break;
                }
            }
