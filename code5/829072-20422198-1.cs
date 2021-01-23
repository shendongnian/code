    var output = input.Where(x=>x.Year == DateTime.Now.Year)
                      .Select(x=> new {x,
                                       LatestWeight = new[]{
                                            x.Jan, x.Feb, x.March, x.April, x.May
                                       }.Select((a,i)=>a + i * 31).Max()
                                      })
                      .OrderByDescending(a=>a.LatestWeight)
                      .Select(a=>a.x).FirstOrDefault();
    //the output is a PersonTimeSheet, you can select what you want from it.
