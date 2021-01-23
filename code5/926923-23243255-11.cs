    public class MyItemsControl : ItemsControl
    {
        static MyItemsControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(MyItemsControl),
                new FrameworkPropertyMetadata(typeof(MyItemsControl)));
        }
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new ContentControl();
        }
    }
