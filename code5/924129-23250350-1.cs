    public class CanvasItemsControl : ItemsControl
    {
        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            base.PrepareContainerForItemOverride(element, item);
            var contentPresenter = (ContentPresenter)element;
            contentPresenter.SetBinding(Canvas.ZIndexProperty, new System.Windows.Data.Binding("ZIndex") { Source = contentPresenter.Content });
        }
    }
