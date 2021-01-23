    protected void rpHostUsersList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    var currentData = ((System.Data.DataRowView)e.Item.DataItem)["Activate"];
                    var b = Convert.ToBoolean(currentData);
                    var btn = (LinkButton)e.Item.FindControl("lnkActivate");
                    btn.CssClass = b ? "myclassBlock" : "myclassNone";
                }
            }
