    public static class ScrollViewerBehavior
        {
            public static readonly DependencyProperty ScrollToRightEndProperty =
                DependencyProperty.RegisterAttached("ScrollToRightEnd", typeof (bool), typeof (ScrollViewerBehavior),
                                                    new PropertyMetadata(false, OnScrollToRightEndPropertyChanged));
    
            public static bool GetScrollToRightEnd(DependencyObject obj)
            {
                return (bool) obj.GetValue(ScrollToRightEndProperty);
            }
    
            public static void SetScrollToRightEnd(DependencyObject obj, bool value)
            {
                obj.SetValue(ScrollToRightEndProperty, value);
            }
    
            private static void OnScrollToRightEndPropertyChanged(DependencyObject sender,
                                                                  DependencyPropertyChangedEventArgs e)
            {
                var sv = sender as ScrollViewer;
                if (sv == null) return;
    
                if ((bool) e.NewValue)
                {
                    sv.ScrollToRightEnd();
                }
                else
                {
                    sv.ScrollToLeftEnd();
                }
            }
        }
