     private void radTreeListView_SelectionChanging(object sender, Telerik.Windows.Controls.SelectionChangingEventArgs e)
        {
            if (e.AddedItems.Count>0)
            {
                if (radTreeListView.SelectedItems.Count >= 5)
                {
                    e.Cancel = true;
                }
                if (radTreeListView.SelectedItems.Count>=1) // a node has been selected before
                {
                    //
                    Category PreviousSelectedItem = (Category)radTreeListView.SelectedItems[0];
                    Category ItemWhichisSelectedNow = (Category)e.AddedItems[0];
                    if (PreviousSelectedItem.Parent != ItemWhichisSelectedNow.Parent)
                    {
                        e.Cancel = true;
                    }
                }
            }
        }
