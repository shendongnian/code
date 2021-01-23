        protected void Parent_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var item = e.Item.DataItem as IGrouping<string, Dog>;
            if (item == null)
                return;
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                var repeater = e.Item.FindControl("Child") as Repeater;
                if (repeater != null)
                {
                    repeater.DataSource = item;
                    repeater.DataBind();
                }
            }
        }
