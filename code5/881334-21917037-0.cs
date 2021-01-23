    public void ClickOnViewerSpace(int addX = 0, int addY = 0)
    {
        //int x = _contentContainer.BoundingRectangle.Location.X;
        //int y = _contentContainer.BoundingRectangle.Location.Y;
        //Mouse.Click(new Point(x + addX, y + addY));
        Mouse.Click(_contentContainer, new Point(addX, addY)); // relative coords
    }
