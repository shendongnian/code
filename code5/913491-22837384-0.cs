        TabControl currentTab = (TabControl)sender;
        TabItem selectedItem = currentTab.SelectedItem as TabItem;
        if (selectedItem != null)
        {
            foreach (TabItem currentItem in currentTab.Items)
            {
                if (currentItem == selectedItem)
                {
                    selectedItem.BorderBrush = new SolidColorBrush() { Color = Colors.Green };
                    selectedItem.Background = new SolidColorBrush() { Color = Colors.LightGray };
                }
                else
                {
                    currentItem.BorderBrush = new SolidColorBrush() { Color = Colors.Blue };
                    currentItem.Background = new SolidColorBrush() { Color = Colors.Gray };
                }
            }
        }
