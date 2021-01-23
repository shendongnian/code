    Random xRnd = new Random(DateTime.Now.Millisecond);
    Random yRnd = new Random(DateTime.Now.Millisecond);
    
    string[,] array = new string[10, 10];
               
    array[xRnd.Next(0, 10), yRnd.Next(0, 10)] = "*";
    var result = 
        Enumerable.Range(0, array.GetUpperBound(0))
        .Select(x => Enumerable.Range(0, array.GetUpperBound(1))
            .Where(y => array[x, y] != null)
            .Select(y => new { X = x, Y = y }))
        .Where(i => i.Any())
        .SelectMany(i => i)
        .ToList();
