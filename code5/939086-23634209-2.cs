    // Changing the class will make this less ugly
    var arc = (DXFLib.DXFArc)entity;
    if (arc.ExtrusionDirection.X == null ||
        arc.ExtrusionDirection.Y == null ||
        arc.ExtrusionDirection.Z == null)
    {
        arc.ExtrusionDirection.X = 0;
        arc.ExtrusionDirection.Y = 0;
        arc.ExtrusionDirection.Z = 1;
    }
    arcSegment.SweepDirection = arc.ExtrusionDirection.Z > 0
        ? SweepDirection.Clockwise
        : SweepDirection.Counterclockwise;
