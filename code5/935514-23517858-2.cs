    public class StretchPanel : Panel
    {
        protected override Size MeasureOverride(Size availableSize)
        {
            foreach (UIElement element in Children)
            {
                element.Measure(new Size());
            }
            return new Size();
        }
        protected override Size ArrangeOverride(Size finalSize)
        {
            for (int i = 0; i < Children.Count; i++)
            {
                int x1 = (int)(finalSize.Width / Children.Count * i);
                int x2 = (int)(finalSize.Width / Children.Count * (i + 1));
                Children[i].Arrange(new Rect(x1, 0, x2 - x1, finalSize.Height));
            }
            return finalSize;
        }
    }
