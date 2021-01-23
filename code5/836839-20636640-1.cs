    // Since there's no common 2d Point double based type,
    // let (x, y) point be represented as Tuple<Double, Double>
    // where Item1 is x, and Item2 is y
    public static Tuple<Double, Double> Move(Tuple<Double, Double> fromPoint,
                                             Tuple<Double, Double> toPoint,
                                             Double velocity,
                                             Double time) {
      Double fi = Math.Atan2(toPoint.Item2 - fromPoint.Item2, toPoint.Item1 - fromPoint.Item1);
    
      return new Tuple<Double, Double>(
        fromPoint.Item1 + velocity * Math.Cos(fi) * time,
        fromPoint.Item2 + velocity * Math.Sin(fi) * time);
    }
    ...
    
    for (int t = 0; t < 10; ++t) {
      Tuple<Double, Double> position = 
        Move(new Tuple<Double, Double>(2.5, 2.5), 
             new Tuple<Double, Double>(6.5, 3.8), 
             2.0, 
             t);
    
      Console.Write("t = ");
      Console.Write(t);
      Console.Write(" x = ");
      Console.Write(position.Item1);
      Console.Write(" y = ");
      Console.Write(position.Item2);
      Console.WriteLine();
    }
  
