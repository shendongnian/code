    var rand = new Random();
    var threshold = 1;
    var points = new List<PointF>();
    for (int i = 0; i < 20; i++)
    {
        points.Add(new PointF((float) rand.NextDouble()*10, (float) rand.NextDouble()*10));
    }
    Console.WriteLine(points.Count);
    for (int i = 0; i < points.Count(); i++)
    {
        for (int j = i + 1; j < points.Count(); )
        {
            var pointHere = points[i];
            var pointThere = points[j];
            var vectorX = pointThere.X - pointHere.X;
            var vectorY = pointThere.Y - pointHere.Y;
            var length = Math.Sqrt(Math.Pow(vectorX, 2) + Math.Pow(vectorY, 2));
            if (length <= threshold)
            {
                points.RemoveAt(j);
            }
            else
            {
                j += 1;
            }
        }
    }
    Console.WriteLine(points.Count);
