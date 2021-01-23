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
            if (AssociatedObject.Items.Any())
            {
                AssociatedObject.ScrollIntoView(AssociatedObject.Items[AssociatedObject.Items.Count - 1]);
            }
        }
    }
