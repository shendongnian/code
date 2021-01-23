        private void Group_Checked(object sender, RoutedEventArgs e)
        {
            var chk = (CheckBox)sender;
            var group = (CollectionViewGroup)chk.DataContext;
            this.HandleGroupCheck(group, true);
        }
        private void Group_Unchecked(object sender, RoutedEventArgs e)
        {
            var chk = (CheckBox)sender;
            var group = (CollectionViewGroup)chk.DataContext;
            this.HandleGroupCheck(group, false);
        }
        private void HandleGroupCheck(CollectionViewGroup group, bool check)
        {
            var items = group.Items;
            foreach (var item in items.Cast<Item>())
            {
                item.Selected = check;
            }
        }
