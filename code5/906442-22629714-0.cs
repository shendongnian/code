    public class ItemsControlBehavior : Behavior<ListBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.ItemContainerGenerator.ItemsChanged += ItemContainerGenerator_ItemsChanged;
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.ItemContainerGenerator.ItemsChanged -= ItemContainerGenerator_ItemsChanged;
        }
        private void ItemContainerGenerator_ItemsChanged(object sender,
            System.Windows.Controls.Primitives.ItemsChangedEventArgs e)
        {
            var childscount = VisualTreeHelper.GetChildrenCount(AssociatedObject);
            for (int i = 0; i < childscount; i++)
            {
                if (VisualTreeHelper.GetChild(AssociatedObject, i) is ScrollViewer)
                {
                    var sv = VisualTreeHelper.GetChild(AssociatedObject, i) as ScrollViewer;
                    sv.ScrollToVerticalOffset(sv.ScrollableHeight);
                    break;
                }
            }
        }
    }
