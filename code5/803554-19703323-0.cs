    var query = _customerRepo.Table
         .GroupBy(c => new {Date = c.Date.Date,  Type = c.TypeOfCustomer})
         .Select(g => new 
                       {
                           Date = g.Key.Date,
                           Type = g.Key.Type, 
                           Count = g.Count
                       }
                )
         .OrderByDescending (r = r.Date);
