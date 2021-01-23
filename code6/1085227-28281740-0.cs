    var query = (from w in db.Waiter
                 join c in db.Client on w.Id equals c.WaiterId
                 group c by new { c.FirstName, c.LastName, c.WaiterId} into g
                 orderby g.Count() descending
                 select new
                 {
                      FirstName = g.Key.FirstName,
                      LastName  = g.Key.LastName,
                      WaiterId  = g.Key.WaiterId,
                      count     = g.Count()
                  });
