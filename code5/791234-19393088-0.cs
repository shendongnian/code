        private DataTemplate dtSmall;
        private DataTemplate dtEnlarged;
        public MainPage()
        {
            this.InitializeComponent();
            dtSmall = (DataTemplate)Resources["dtSmall"];
            dtEnlarged = (DataTemplate)Resources["dtEnlarged"];
        }
        // A selected item is treated as an expanded/enlarged item
        private void LVEnlargeable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /* First we set all the items that has been deselected
            to be collapsed, aka. using the dtSmall DataTemplate.
            We expect 0 or 1 item to have been deselected
            but handle all cases easily with a foreach loop.
            */
            foreach (var item in e.RemovedItems)
            {
                // Set the DataTemplate of the deselected ListViewItems
                ((ListViewItem)(sender as ListView).ContainerFromItem(item)).ContentTemplate = dtSmall;
            }
            /* Then we set all the items that has been selected
            to be expanded.
            We should probably throw an Exception if more than 1 was found,
            because it's unwanted behavior, but we'll ignore that for now.
            */
            foreach (var item in e.AddedItems)
            {
                ((ListViewItem)(sender as ListView).ContainerFromItem(e.AddedItems[0])).ContentTemplate = dtEnlarged;
            }
        }
        /* We need click events because SelectionChanged-events
        cannot detect clicks on an already selected item */
        private void LVEnlargeable_ItemClick(object sender, ItemClickEventArgs e)
        {
            ListView lv = (sender as ListView);
            /* Having set the IsItemClickEnabled property on the ListView to True
            we have to handle selection events manually.
            If nothing is selected when this click occurs, then select this item*/
            if (lv.SelectedItem == null)
            {
                lv.SelectedItem = e.ClickedItem;
            }
            else
            {
                // Clicking on an expanded/selected/enlarged item will deselect it
                if (lv.SelectedItem.Equals(e.ClickedItem))
                {
                    lv.SelectedItem = null;
                }
                else
                {   /* If it's not a selected item, then select it
                        (and let SelectionChanged unselect the already selected item) */
                    lv.SelectedItem = e.ClickedItem;
                }
            }
        }
    }
