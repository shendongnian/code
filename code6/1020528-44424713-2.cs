    public static Point AlignDrawingPoint(this Graphics g, Size objectSize, Rectangle clientRectangle, ContentAlignment alignment)
    {
    	int margin = 4;
    	Point center = new Point((clientRectangle.Width >> 1) - (objectSize.Width >> 1), (clientRectangle.Height >> 1) - (objectSize.Height >> 1));
    	int rightMargin = clientRectangle.Width - (objectSize.Width + margin);
    	int bottomMargin = clientRectangle.Height - (objectSize.Height + margin);
    	Point p = Point.Empty;
    	switch (alignment)
    	{
    		case ContentAlignment.TopLeft:
    			p = new Point(margin, margin);
    			break;
    		case ContentAlignment.TopCenter:
    			p = new Point(center.X, margin);
    			break;
    		case ContentAlignment.TopRight:
    			p = new Point(rightMargin, margin);
    			break;
    		case ContentAlignment.MiddleLeft:
    			p = new Point(margin, center.Y);
    			break;
    		case ContentAlignment.MiddleCenter:
    			p = new Point(center.X, center.Y);
    			break;
    		case ContentAlignment.MiddleRight:
    			p = new Point(rightMargin, center.Y);
    			break;
    		case ContentAlignment.BottomLeft:
    			p = new Point(margin, bottomMargin);
    			break;
    		case ContentAlignment.BottomCenter:
    			p = new Point(center.X, bottomMargin);
    			break;
    		case ContentAlignment.BottomRight:
    			p = new Point(rightMargin, bottomMargin);
    			break;
    	}
    	p.Offset(clientRectangle.X, clientRectangle.Y);
    	return p;
    }
