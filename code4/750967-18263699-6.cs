    var result = Customers.GroupBy(x=> Customers.Count(a=>a.Name == x.Name) == 1 ? 1 :
                                       x.CheckInDate != yourDate ? 2 : 3)
                          .Select(g=> g.ToList()).ToList();
    //To get the customers who have first checked in
    var firstCheckedIn = result[0];
    //To get the customers who didn't check in on a given date
    var notCheckedIn = result[1].Except(result[2]);
   
    //or
    var result = Customers.GroupBy(x=> {
                                        var c = Customers.Where(a=>a.Name == x.Name);
                                        return c.Count() == 1 ? 1 :
                                               !c.Any(a=>a.CheckInDate == yourDate) ? 2 : 3;
                                       })                                        
                          .Select(g=> g.ToList()).ToList();
