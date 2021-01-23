    public class MyItemsControl : ItemsControl
    {
        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            base.PrepareContainerForItemOverride(element, item);
            FrameworkElement source = element as FrameworkElement;
            source.SetBinding(Grid.ColumnProperty, new Binding { Path = new PropertyPath("ColumnIndex") });
        }
    }
