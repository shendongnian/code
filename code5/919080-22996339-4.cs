    public class ListBoxSelectedItemsBehavior : Behavior<ListBox>
    {
        protected override void OnAttached()
        {
            AssociatedObject.SelectionChanged += AssociatedObjectSelectionChanged;
        }
        protected override void OnDetaching()
        {
            AssociatedObject.SelectionChanged -= AssociatedObjectSelectionChanged;
        }
        void AssociatedObjectSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Assuming your selection mode is single.
            AssociatedObject.ScrollIntoView(e.AddedItems[0]);
        }
