    public ColumnElevationRebar Clone()
    {
        var obj = new ColumnElevationRebar();
        obj.CanBeContinued = CanBeContinued;
        obj.CanBeSpliced = CanBeContinued;
        obj.ConnectionType = ConnectionType;
        obj.SpliceLength = SpliceLength;
        obj.Polyline = Polyline.Clone();
        return obj;
    }
