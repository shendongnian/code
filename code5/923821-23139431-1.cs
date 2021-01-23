    Geometry GetGeometry(Shape shape)
    {
        Rectangle rectangle = shape as Rectangle;
        if (rectangle != null)
        {
           return new RectangleGeometry(new Rect(0, 0, 1, 1), rectangle.RadiusX, rectangle.RadiusY, rectangle.GeometryTransform);
        }
        Ellipse ellipse = shape as Ellipse;
        if (ellipse != null)
        {
           //...
        }
        // ...
    }
