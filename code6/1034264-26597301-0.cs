    public List<Tuple<TimeSpan, Vector2>> Points { get; set; }
    public Vector2 CurrentPoint { get; set; }
    public void Update(GameTime gameTime)
    {
        Points.Add(new Tuple<TimeSpan, Vector2>(TimeSpan.FromSeconds(1), mouseCoords));
        foreach(var point in Points)
        {
            point.Item1 -= gameTime.ElapsedTimeSpan;
            if (point.Item1 < TimeSpan.Zero)point
                CurrentPoint = point.Item2;
        }
    }
