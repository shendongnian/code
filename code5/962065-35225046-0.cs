    public class SplitPanel : Panel
    {
        protected override Size MeasureOverride(Size availableSize)
        {
            // the final measure size is the available size for the width, and the maximum
            // desired size of our children for the height
            Size finalSize = new Size { Width = availableSize.Width };
    
            if (this.Children.Count != 0)
                availableSize.Width /= (double)this.Children.Count;
    
            foreach (var current in this.Children)
            {
                current.Measure(availableSize);
    
                Size desiredSize = current.DesiredSize;
                finalSize.Height = Math.Max(finalSize.Height, desiredSize.Height);
            }
    
            // make sure it will works in design time mode
            if (double.IsPositiveInfinity(finalSize.Height) || double.IsPositiveInfinity(finalSize.Width))
                return Size.Empty;
    
            return finalSize;
        }
    
        protected override Size ArrangeOverride(Size arrangeSize)
        {
            Rect finalRect = new Rect(new Point(), arrangeSize);
            double width = arrangeSize.Width / this.Children.Count;
    
            foreach (var child in this.Children)
            {
                finalRect.Height = Math.Max(arrangeSize.Height, child.DesiredSize.Height);
                finalRect.Width = width;
    
                child.Arrange(finalRect);
    
                // move each child by the width increment 
                finalRect.X += width;
            }
    
            return arrangeSize;
        }
    }
