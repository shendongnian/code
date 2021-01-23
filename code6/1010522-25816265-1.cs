    void savePoints(List<Point> points, string filename)
    {   StringBuilder SB = new StringBuilder();
        foreach (Point P in points) SB.AppendLine(P.X.ToString() + ";" + P.Y.ToString());
        File.WriteAllText(filename, SB.ToString());
    }
    List<Point> loadPoints(string filename)
    {   List<Point> points = new List<Point>();
        var lines = File.ReadAllLines(filename);
        foreach (string l in lines)
        {
            var p = l.Split(';');
            points.Add(new Point(Convert.ToInt16(p[0]), Convert.ToInt16(p[1])));
        }
        return points;
    }
