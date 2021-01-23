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
            int index = 0;
            foreach (UIElement element in Children)
            {
                int x1 = (int)(finalSize.Width / Children.Count * index);
                int x2 = (int)(finalSize.Width / Children.Count * (index + 1));
                index++;
                element.Arrange(new Rect(x1, 0, x2 - x1, finalSize.Height));
            }
            return finalSize;
        }
    }
