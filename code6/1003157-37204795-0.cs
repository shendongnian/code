                if (e.AddedItems != null)
            {
                foreach (var item in e.AddedItems)
                {
                    ListViewItem litem = (sender as ListView).ContainerFromItem(item) as ListViewItem;
                    if (litem != null)
                    {
                        VisualStateManager.GoToState(litem, "Unfocused", true);
                        VisualStateManager.GoToState(litem, "Normal", true);
                        VisualStateManager.GoToState(litem, "Selected", true);
                    }
                }
            }
            if (e.RemovedItems != null)
            {
                foreach (var item in e.RemovedItems)
                {
                    ListViewItem litem = (sender as ListView).ContainerFromItem(item) as ListViewItem;
                    if (litem != null)
                    {
                        VisualStateManager.GoToState(litem, "Unselected", true);
                    }
                }
