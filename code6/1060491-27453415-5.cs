    public static void Main()
    {
        var points = new List<Point>
        {
            new Point(1, 2),
            new Point(3, 4)
        };
        var gazePoints = new List<GazePoint>
        {
            new GazePoint(1, 2),
            new GazePoint(3, 4)
        };
        Point avgPoint = AvgPoint(points);
        Point avgGazePoint = AvgPoint(gazePoints);
        Console.WriteLine("Average Point = {0}, {1}", avgPoint.X, avgPoint.Y);
        Console.WriteLine("Average GazePoint = {0}, {1}", avgGazePoint.X, avgGazePoint.Y);
    }
