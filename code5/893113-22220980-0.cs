    public class CachingItemsControl : ItemsControl
    {
        private readonly Stack<DependencyObject> itemContainers =
            new Stack<DependencyObject>();
        protected override DependencyObject GetContainerForItemOverride()
        {
            return itemContainers.Count > 0
                ? itemContainers.Pop()
                : new ContentPresenter();
        }
        protected override void ClearContainerForItemOverride(
            DependencyObject element, object item)
        {
            itemContainers.Push(element);
        }
    }
