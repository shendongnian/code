            var selector = sender as MultiSelector;
            //// with this way you can call the scrolling item into view even if the items are virtualized.
            //// works only for VirtualizingPanel.VirtualizationMode="Standard" not for recycle mode.
            var itemsHost = typeof(MultiSelector).InvokeMember("ItemsHost", BindingFlags.NonPublic | BindingFlags.GetProperty | BindingFlags.Instance, null, selector, null);
            VirtualizingPanel virtualPanel = itemsHost as VirtualizingPanel;
            if (virtualPanel != null && selector.SelectedIndex >= 0)
            {
                virtualPanel.BringIndexIntoViewPublic(selector.SelectedIndex);
            }
