    public class UIElementContainer : UIElement
    {
        private readonly UIElementCollection children;
        public UIElementContainer()
        {
            children = new UIElementCollection(this, null);
        }
        public void AddChild(UIElement element)
        {
            children.Add(element);
        }
        public void RemoveChild(UIElement element)
        {
            children.Remove(element);
        }
        protected override int VisualChildrenCount
        {
            get { return children.Count; }
        }
        protected override Visual GetVisualChild(int index)
        {
            return children[index];
        }
        protected override Size MeasureCore(Size availableSize)
        {
            foreach (UIElement element in children)
            {
                element.Measure(availableSize);
            }
            return new Size();
        }
        protected override void ArrangeCore(Rect finalRect)
        {
            foreach (UIElement element in children)
            {
                element.Arrange(finalRect);
            }
        }
    }
