    public class MyFilterLogic: Behavior<CollectionViewSource>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Filter += AssociatedObjectOnFilter;
        }
        private void AssociatedObjectOnFilter(object sender, FilterEventArgs filterEventArgs)
        {
            // filter logic
        }
    }
