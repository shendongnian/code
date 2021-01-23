    //just for testing a list of locations
    givenCoordinates = new double[3, 2];
    givenCoordinates[0, 0] = 23.4896;
    givenCoordinates[0, 1] = 12.1392;
    givenCoordinates[1, 0] = 23.4835;
    givenCoordinates[1, 1] = 12.1794;
    givenCoordinates[2, 0] = 23.5153;
    givenCoordinates[2, 1] = 12.1516;
    drawMap();
    
    await Task.Run(async () =>
    {
        Thread.Sleep(1);
        Dispatcher.BeginInvoke(() =>
        {
            delMap.SetView(LocationRectangle.CreateBoundingRectangle(locations), MapAnimationKind.Linear);
        });
    });
