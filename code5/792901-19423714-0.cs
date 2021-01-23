    private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabItem selectedTab = e.AddedItems[0] as TabItem;  // Gets selected tab
    
            if (selectedTab.Name == "Tab1")
            {
                // Do work Tab1
            }
            else if (selectedTab.Name == "Tab2")
            {
                // Do work Tab2
            }
        }
