    var output = input.Where(x=>x.Year == DateTime.Now.Year)
                      .Select(x=> new {x,
                                   LatestDay = new[]{
                                   x.May, x.April, x.March, x.Feb, x.Jan
                                 }.Max())
                      .OrderByDescending(a=>a.LatestDay)
                      .Select(a=>a.x.Name).FirstOrDefault();                      
