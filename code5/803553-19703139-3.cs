    var query = from c in _customerRepo.Table
                group c by new { c.TypeOfCustomer, c.Date } into g
                orderby g.Key.Date descending
                select new {
                   g.Key.Date,
                   g.Key.TypeOfCustomer,
                   Count = g.Count()
                };
