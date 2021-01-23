    /// <summary>
    /// Test whether the mouse is within a shape
    /// </summary>
    /// <param name="shape">The shape to test</param>
    /// <param name="e">MouseEventArgs</param>
    /// <returns>TRUE if the mouse is within the bounding box of the shape; FALSE otherwise</returns>
    private bool MouseWithinShape(PPShape shape, System.Windows.Forms.MouseEventArgs e)
    {
        // Fetch the bounding box of the shape
        RectangleF shapeRect = shape.Rectangle;
        // Transform to screen pixels
        Rectangle shapeRectInScreenPixels = PointsToScreenPixels(shapeRect);
        // Test whether the mouse is within the bounding box
        return shapeRectInScreenPixels.Contains(e.Location);
    }
    /// <summary>
    /// Transforms a RectangleF with PowerPoint points to a Rectangle with screen pixels
    /// </summary>
    /// <param name="shapeRectangle">The Rectangle in PowerPoint point-units</param>
    /// <returns>A Rectangle in screen pixel units</returns>
    private Rectangle PointsToScreenPixels(RectangleF shapeRectangle)
    {
        // Transform the points to screen pixels
        int x1 = pointsToScreenPixelsX(shapeRectangle.X);
        int y1 = pointsToScreenPixelsY(shapeRectangle.Y);
        int x2 = pointsToScreenPixelsX(shapeRectangle.X + shapeRectangle.Width);
        int y2 = pointsToScreenPixelsY(shapeRectangle.Y + shapeRectangle.Height);
        // Expand the bounding box with a standard padding
        // NOTE: PowerPoint transforms the mouse cursor when entering shapes before it actually
        // enters the shape. To account for that, add this extra 'padding'
        // Testing reveals that the current value (in PowerPoint 2013) is 6px
        x1 -= 6;
        x2 += 6;
        y1 -= 6;
        y2 += 6;
            
        // Return the rectangle in screen pixel units
        return new Rectangle(x1, y1, x2-x1, y2-y1);
    }
    /// <summary>
    /// Transforms a PowerPoint point to screen pixels (in X-direction)
    /// </summary>
    /// <param name="point">The value of point to transform in PowerPoint point-units</param>
    /// <returns>The screen position in screen pixel units</returns>
    private int pointsToScreenPixelsX(float point)
    {
        // TODO Handle multiple windows
        // NOTE: PresStatic is a reference to the PowerPoint presentation object
        return PresStatic.Windows[1].PointsToScreenPixelsX(point);
    }
    /// <summary>
    /// Transforms a PowerPoint point to screen pixels (in Y-direction)
    /// </summary>
    /// <param name="point">The value of point to transform in PowerPoint point-units</param>
    /// <returns>The screen position in screen pixel units</returns>
    private int pointsToScreenPixelsY(float point)
    {
        // TODO Handle multiple windows
        // NOTE: PresStatic is a reference to the PowerPoint presentation object
        return PresStatic.Windows[1].PointsToScreenPixelsY(point);
    }
