    private Random random = new Random(); // creates some sample data
    private void CompositionTarget_Rendering(object sender, EventArgs e)
    {
        var line = new Point[480];
        for (int i = 0; i < line.Length; i++ )
        {
            line[i] = new Point(i, random.Next(0, 100));
        }
        MyFigure1.StartPoint = line[0];
        MySegment1.Points = new PointCollection(line); // here
    }
