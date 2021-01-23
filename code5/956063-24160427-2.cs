    var result = from customer in Customers
                 join house in Houses 
                 on customer.CustomNumber equals house.CustomNumber
                 where customer.CustomNumber == 2               
                 group new { Customer = customer, House = house } 
                 by new { customer.Name, house.StartDate}              
                 into grp              
                 select new               
                 {
                     Name = grp.Key.Name,
                     StartDate = grp.Max(x=>x.StartDate)              
                 }; 
