    private void ArrangeLine(double y, Size lineSize, double boundsWidth, int start, int end)
    {
        double x = 0;
        UIElementCollection children = InternalChildren;
        for (int i = start; i < end; i++)
        {
            UIElement child = children[i];
            var w = child.DesiredSize.Width;
            if (LastChildFill && i == end - 1) // last сhild fills remaining space
            {
                w = boundsWidth - x;
            }
            child.Arrange(new Rect(x, y, w, lineSize.Height));
            x += w;
        }
    }
