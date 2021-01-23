    public Polyline Clone()
    {
        var obj = new Polyline {Points = new List<_2DPoint>(this.Points)};
        return obj;
    }
