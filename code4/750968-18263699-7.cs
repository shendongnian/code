    var result = Customers.GroupBy(x=> Customers.Count(a=>a.Name == x.Name) == 1 ? 1 : 2)
                          .Select(g=> g.Key == 1 ? g.ToList() : g.Where(x=>!g.Where(a=>a.CheckInDate == yourDate)
                                                                             .Any(a=>a.Name == x.Name)).ToList());
    //To get the customers who have first checked in
    var firstCheckedIn = result[0];
    //To get the customers who didn't check in on a given date
    var notCheckedIn = result[1]
   
    //or
    var result = Customers.GroupBy(x=> {
                                        var c = Customers.Where(a=>a.Name == x.Name);
                                        return c.Count() == 1 ? 1 :
                                               !c.Any(a=>a.CheckInDate == yourDate) ? 2 : 3;
                                       })                                        
                          .Select(g=> g.ToList()).ToList();
