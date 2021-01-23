    public class CanvasItemsControl : ItemsControl
    {
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new SInGame();
        }
        // Any setup of the `SInGame` items should be done here
        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            base.PrepareContainerForItemOverride(element, item);
            var container = (SInGame)element;
        }
    }
