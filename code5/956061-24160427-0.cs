    var result = from Cus in Customers
                 where Cus.CustomNumber == 2 
                 group Cus by new 
                 { Cus.Name, Cus.StartDate}
                 into grp
                 select new 
                 {
                     Name = grp.Key.Name,
                     StartDate = grp.Max(x=>x.StartDate)
                 }
