        public class ScrollableListView : ListView
        {
            /// <summary>
            /// Set this property to make ListView scroll to it
            /// </summary>
            public object TargetListItem
            {
                get { return (object)GetValue(TargetListItemProperty); }
                set { SetValue(TargetListItemProperty, value); }
            }
    
            public static readonly DependencyProperty TargetListItemProperty = DependencyProperty.Register(
                nameof(TargetListItem), typeof(object), typeof(ScrollableListView), new PropertyMetadata(null, TargetListItemPropertyChangedCallback));
    
            static void TargetListItemPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                var owner = (ScrollableListView)d;
                owner.ScrollToItem(e.NewValue);
            }
    
            public void ScrollToItem(object value)
            {
                if (value != null && Items != null && Items.Contains(value))
                {
                    ScrollIntoView(value);
                }
            }
        }
