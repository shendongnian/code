    public class CanvasItemsControl : ItemsControl
    {
        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            base.PrepareContainerForItemOverride(element, item);
            var contentPresenter = (ContentPresenter)element;
            var binding = new Binding("ZIndex") { Source = contentPresenter.Content };
            contentPresenter.SetBinding(Canvas.ZIndexProperty, binding);
        }
    }
