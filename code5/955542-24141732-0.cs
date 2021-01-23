    ModelBeams.ForEach(mb => 
    {
        linesPassingThroughBeamEndsInYDirection.Add(mb.ConnectivityLine.I.Y);
        linesPassingThroughBeamEndsInYDirection.Add(mb.ConnectivityLine.J.Y);
    });
