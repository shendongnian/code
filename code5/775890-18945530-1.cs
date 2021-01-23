        public static class TabItemBehaviour
        {
            public static readonly DependencyProperty IsCloseButtonVisibleProperty =
                DependencyProperty.RegisterAttached("IsCloseButtonVisible", typeof(bool), typeof(TabItemBehaviour), new UIPropertyMetadata(true, IsButtonVisiblePropertyChanged));
    
            public static bool GetIsCloseButtonVisible(DependencyObject obj)
            {
                return (bool)obj.GetValue(IsCloseButtonVisibleProperty);
            }
    
            public static void SetIsCloseButtonVisible(DependencyObject obj, bool value)
            {
                obj.SetValue(IsCloseButtonVisibleProperty, value);
            }
    
            public static void IsButtonVisiblePropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
            {
                TabItem item = o as TabItem;
                if (item != null)
                {
                   Button closeButton = item.Template.FindName("CloseButton", item) as Button;
                   if ((bool)e.NewValue == true)
                   {
                       closeButton.Visibility = Visibility.Visible;
                   }
                   else
                   {
                       closeButton.Visibility = Visibility.Collapsed;
                   }
                }
            }
        }
 
