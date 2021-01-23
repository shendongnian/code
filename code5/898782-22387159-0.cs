     int[,] result = new int[4, 4];
    
     int i = 0;
     var dict = File.ReadAllText(@"C:\Left.txt")
                    .SelectMany(x => x.Split())
                     .Select((number, idx) => new {number, idx})
                    .GroupBy(x => x.idx/4)
                    .ToDictionary(x => i++, x => x.Select(y => int.Parse(y.number)).ToList());
    foreach (var key in dict.Keys)
    {
         for (int k = 0; k < 4; k++)
         {
             result[key, k] = dict[key][k];
         }
    }
