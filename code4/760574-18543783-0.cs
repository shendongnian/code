    //build the data to test
    List<DateTime> data = new List<DateTime>();
    Random rand = new Random();
    for (int i = 0; i < 50; i++) {
       data.Add(new DateTime(2013, 12, 22, 12, rand.Next(50),0));
    }
    //----------
    DateTime fix = DateTime.Now;
    int j = 0;
    var result = data.OrderBy(x => x)
                             .Select((x,i)=>new{x,i})
                             .GroupBy(x=> {
                                 if(x.i == 0) fix = x.x;
                                 else if ((x.x - fix).TotalMinutes >= 2)
                                 {
                                     fix = x.x;
                                     j++;
                                 }
                                 return j;
                                }, e=>e.x, (key,e)=>e.First());
