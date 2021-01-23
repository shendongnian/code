    using(var externalPath = new GraphicsPath(FillMode.Alternate))
    {
        externalPath.AddRectangle(pathRegion);
        externalPath.AddRectangle(linearGradientregion);
        graphics.FillPath(Brushes.Black, externalPath);
    }
    
