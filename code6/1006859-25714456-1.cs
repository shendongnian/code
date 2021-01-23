    public static IEnumerable<Point> ToPoints(this List<int> source)
    {
        for (int i = 0; i < source.Count; i += 2)
        {
            yield return new Point(source[i], source[i + 1]);
        }
    }
