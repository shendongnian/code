    int temp = -1;
    var mode = numArray.GroupBy(v => v)
                       .OrderByDescending(g => g.Count())
                       .TakeWhile(g => {
                             if(temp == -1)
                                 temp = g.Count();
                             return temp == g.Count(); })
                       .Select(g => g.Key)
                       .ToArray();
                        
