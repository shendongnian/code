    linesPassingThroughBeamEndsInYDirection.AddRange(
       ModelBeams.SelectMany(beam => new [] {
                                             beam.ConnectivityLine.I.Y, 
                                             beam.ConnectivityLine.J.Y}
                            ));
                                   
