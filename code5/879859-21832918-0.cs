    private void CompositionTarget_Rendering(object sender, EventArgs e)
    {
        var line = new Point[480];
        for (int i = 0; i < line.Length; i++ )
        {
            line[i] = new Point(i, i);
        }
        MySegment1.Points = new PointCollection(line); // here
    }
