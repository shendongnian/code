    var query = from p in parents
           join c in children
           on p.ID equals c.ParentID into g
           select new
           {
              ParentID = p.ID,
              PrimaryChildID = g.Select(x => x.ID).FirstOrDefault(),
              Description = p.Description,
              SubDescription = g.Select(x => x.Description).FirstOrDefault(),
              ConditionalCount = g.Count(x => x.Condition != null)
           };
