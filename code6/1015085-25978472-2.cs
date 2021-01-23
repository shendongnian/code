    /// <summary>
    /// Gets the bounding rectangle of a given element
    /// relative to a given other element or visual root
    /// if relativeTo is null or not specified.
    /// </summary>
    /// <remarks>
    /// Note that the bounding box is calculated based on the corners of the element relative to itself,
    /// so e.g. a bounding box of a rotated ellipse will be larger than necessary and in general
    /// bounding boxes of elements with transforms applied to them will often be calculated incorrectly.
    /// </remarks>
    /// <param name="dob">The starting element.</param>
    /// <param name="relativeTo">The relative to element.</param>
    /// <returns></returns>
    /// <exception cref="System.InvalidOperationException">Element not in visual tree.</exception>
    public static Rect GetBoundingRect(this FrameworkElement dob, FrameworkElement relativeTo = null)
    {
        if (DesignMode.DesignModeEnabled)
        {
            return Rect.Empty;
        }
        if (relativeTo == null)
        {
            relativeTo = Window.Current.Content as FrameworkElement;
        }
        if (relativeTo == null)
        {
            throw new InvalidOperationException("Element not in visual tree.");
        }
        if (dob == relativeTo)
        {
            return new Rect(0, 0, relativeTo.ActualWidth, relativeTo.ActualHeight);
        }
        var ancestors = dob.GetAncestors().ToArray();
        if (!ancestors.Contains(relativeTo))
        {
            throw new InvalidOperationException("Element not in visual tree.");
        }
        var topLeft =
            dob
                .TransformToVisual(relativeTo)
                .TransformPoint(new Point());
        var topRight =
            dob
                .TransformToVisual(relativeTo)
                .TransformPoint(
                    new Point(
                        dob.ActualWidth,
                        0));
        var bottomLeft =
            dob
                .TransformToVisual(relativeTo)
                .TransformPoint(
                    new Point(
                        0,
                        dob.ActualHeight));
        var bottomRight =
            dob
                .TransformToVisual(relativeTo)
                .TransformPoint(
                    new Point(
                        dob.ActualWidth,
                        dob.ActualHeight));
        var minX = new[] { topLeft.X, topRight.X, bottomLeft.X, bottomRight.X }.Min();
        var maxX = new[] { topLeft.X, topRight.X, bottomLeft.X, bottomRight.X }.Max();
        var minY = new[] { topLeft.Y, topRight.Y, bottomLeft.Y, bottomRight.Y }.Min();
        var maxY = new[] { topLeft.Y, topRight.Y, bottomLeft.Y, bottomRight.Y }.Max();
        return new Rect(minX, minY, maxX - minX, maxY - minY);
    }
