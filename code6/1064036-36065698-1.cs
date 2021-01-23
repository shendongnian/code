    Point3D[,] dataPoints = new Point3D[10,10]; // i will assume this has already been populated.
    ContainerUIElement3D container;
    Material defaultMaterial = Materaials.Blue;
    for (int x = 0;x < 10; x++)
    {
        for(int y = 0; y < 10; y++)
        {
            Point3D position = dataPoints [x, y];
            InteractivePoint  interactivePoint = new InteractivePoint( position, defaultMaterial );
            container.Children.Add( interactivePoint );
        }
    }
