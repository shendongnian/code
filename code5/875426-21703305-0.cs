    if (e.Item is GridDataItem && e.Item.Edit)
            {
                GridDataItem item = (GridDataItem)e.Item;
                Button btn = (Button)item.FindControl("UpdateButton");
                btn.Attributes.Add("OnClick", "return confirmBox();");
            }
