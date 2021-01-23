    private PointF FixAlignment(RectangleF parentRect, RectangleF childRect,
        StringAlignment lineAlignment, StringAlignment alignment)
    {
        float xOffset = 0;
        float yOffset = 0;
    
        switch (lineAlignment)
        {
            case StringAlignment.Near:
                yOffset = parentRect.Top - childRect.Top;
                break;
            case StringAlignment.Far:
                yOffset = parentRect.Bottom - childRect.Bottom;
                break;
        }
    
        switch (alignment)
        {
            case StringAlignment.Near:
                xOffset = parentRect.Left - childRect.Left;
                break;
            case StringAlignment.Far:
                xOffset = parentRect.Right - childRect.Right;
                break;
        }
    
        return new PointF(xOffset, yOffset);
    }
