    public class UIElementContainer : UIElement
    {
        private readonly List<UIElement> children = new List<UIElement>();
        public void AddChild(UIElement element)
        {
            children.Add(element);
            AddVisualChild(element);
        }
        public void RemoveChild(UIElement element)
        {
            if (children.Remove(element))
            {
                RemoveVisualChild(element);
            }
        }
        // plus the four overrides
    }
