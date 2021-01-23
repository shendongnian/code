    public class ScrollLimiterPanel : Panel
    {
        protected override Size MeasureOverride(Size availableSize)
        {
            var children = InternalChildren.OfType<UIElement>();
            var firstChild = children.FirstOrDefault();
            if (firstChild != null)
                firstChild.Measure(new Size(0, 0));
            return new Size(0, 0);
        }
        protected override Size ArrangeOverride(Size finalSize)
        {
            var children = InternalChildren.OfType<UIElement>();
            var firstChild = children.FirstOrDefault();
            if (firstChild != null)
                firstChild.Arrange(new Rect(0, 0, finalSize.Width, finalSize.Height));
            return finalSize;
        }
    }
