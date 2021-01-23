        private void OnGroupChecked(object sender, RoutedEventArgs e)
        {
            this.HandleGroupCheck((CheckBox)sender, true);
        }
        private void OnGroupUnchecked(object sender, RoutedEventArgs e)
        {
            this.HandleGroupCheck((CheckBox)sender, false);
        }
        private void HandleGroupCheck(CheckBox sender, bool check)
        {
            var group = (CollectionViewGroup) sender.DataContext;
            this.HandleGroupCheckRecursive(group, check);
        }
        private void HandleGroupCheckRecursive(CollectionViewGroup group, bool check)
        {
            foreach (var itemOrGroup in group.Items)
            {
                if (itemOrGroup is CollectionViewGroup)
                {
                    // Found a nested group - recursively run this method again
                    this.HandleGroupCheckRecursive(itemOrGroup as CollectionViewGroup, check);
                }
                else if (itemOrGroup is Item)
                {
                    var item = (Item)itemOrGroup;
                    item.Selected = check;
                }
            }
        }
