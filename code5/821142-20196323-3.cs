    var users = db.Orders.Include(o => o.User)
               .Where(o => o.IsConfirmed == true && 
                                            o.IsSettledWithSalary == false)
               .GroupBy(order => order.UserId)
               .Select(group => new OrderTotalViewModel
               {
                    User = u.First().Name, // or u.FirstName etc...
                    Total = u.Sum(order => order.UnitPrice * order.Quantity)
               });
    
