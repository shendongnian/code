      protected void RadGrid1_CustomAggregate(object sender, GridCustomAggregateEventArgs e)
        {
            if (e.Item is GridGroupFooterItem)
            {
                GridGroupFooterItem footer = e.Item as GridGroupFooterItem;
                GridItem[] groups = RadGrid1.MasterTableView.GetItems(GridItemType.GroupHeader);
                foreach (GridGroupHeaderItem group in groups)
                {
                    if (group.GroupIndex == footer.GroupIndex)
                    {
                        int count = 0;
                        e.Result = Calculate(group, count);
                    }
                }
            }
            if (e.Item is GridFooterItem)
            {
                e.Result = 5;
            }
        }
