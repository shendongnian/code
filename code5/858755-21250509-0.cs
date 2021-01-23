    // I've used Tupple<Double, Double> to represent a point;
    // Ypu, probably have your own type for it
    public static IList<Tuple<Double, Double>> SplitLine(
      Tuple<Double, Double> a, 
      Tuple<Double, Double> b, 
      int count) {
    
      count = count + 1;
    
      Double d = Math.Sqrt((a.Item1 - b.Item1) * (a.Item1 - b.Item1) + (a.Item2 - b.Item2) * (a.Item2 - b.Item2)) / count;
      Double fi = Math.Atan2(b.Item2 - a.Item2, b.Item1 - a.Item1);
    
      List<Tuple<Double, Double>> points = new List<Tuple<Double, Double>>(count + 1);
    
      for (int i = 0; i <= count; ++i)
        points.Add(new Tuple<Double, Double>(a.Item1 + i * d * Math.Cos(fi), a.Item2 + i * d * Math.Sin(fi)));
    
      return points;
    }
    
    ...
    
    IList<Tuple<Double, Double>> points = SplitLine(
      new Tuple<Double, Double>(35.163, 128.001),
      new Tuple<Double, Double>(36.573, 128.707),
      8);
