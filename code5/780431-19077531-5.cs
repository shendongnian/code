    private void OnLongListSelectorItemHold(object sender, GestureEventArgs e)
        {
            FrameworkElement fe = sender as FrameworkElement;
            var storyboard = fe.Resources["ItemHoldAnimation"] as Storyboard;
            storyboard.Begin();
        }
    private void ContextMenu_OnClosed(object sender, RoutedEventArgs e)
        {
            ContextMenu eleme=sender as ContextMenu;
            FrameworkElement fe = eleme.Owner as FrameworkElement;
            var storyboard = fe.Resources["MenuClosedAnimation"] as Storyboard;
            storyboard.Begin();
        }
