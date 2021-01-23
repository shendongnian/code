    public class CustomPanel : Panel
    {
        protected override Size ArrangeOverride(Size finalSize)
        {
            if (Children.Count == 1)
            {
                Children[0].Arrange(new Rect(new Point(0, 0), finalSize));
            }
            else if (Children.Count == 2)
            {
                var halfFinalSize = new Size(finalSize.Width, finalSize.Height/2);
                Children[0].Arrange(new Rect(new Point(0, 0), halfFinalSize));
                Children[1].Arrange(new Rect(new Point(0, finalSize.Height / 2), halfFinalSize));
            }
            else if (Children.Count == 3)
            {
                var halfFinalSize = new Size(finalSize.Width, finalSize.Height / 2);
                var quarterSize = new Size(finalSize.Width / 2, finalSize.Height / 2);
    
                Children[0].Arrange(new Rect(new Point(0, 0), halfFinalSize));
                Children[1].Arrange(new Rect(new Point(0, finalSize.Height / 2), quarterSize));
                Children[2].Arrange(new Rect(new Point(finalSize.Width / 2, finalSize.Height / 2), quarterSize));
            }
            else if (Children.Count == 4)
            {
                var quarterSize = new Size(finalSize.Width / 2, finalSize.Height / 2);
                Children[0].Arrange(new Rect(new Point(0, 0), quarterSize));
                Children[1].Arrange(new Rect(new Point(finalSize.Width / 2, 0), quarterSize));
                Children[2].Arrange(new Rect(new Point(0, finalSize.Height / 2), quarterSize));
                Children[3].Arrange(new Rect(new Point(finalSize.Width / 2, finalSize.Height / 2), quarterSize));
            }
            else if (Children.Count > 4)
            {
                //???
            }
    
            return base.ArrangeOverride(finalSize);
        }
    }`
