     var numbers = File.ReadLines("path")
                       .SelectMany(x => x.Split(','))
                       .Select(x => Convert.ToDouble(x))
                       .ToList();
    
     double[] dx = new double[numbers.Count];
     double[] dy = new double[numbers.Count];
     for (long li = 0; li < numbers.Count; li+=2)
     {
            dx[li] = numbers[li];
            dy[li] = numbers[li +1];
     }
    
