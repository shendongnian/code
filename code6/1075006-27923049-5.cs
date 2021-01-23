    var query = from p in parents
           join c in children
           on p.ID equals c.ParentID into g
           let firstNullElement = g.FirstOrDefault(x => x.Condition == null)
           select new
          {
             ParentID = p.ID,
             PrimaryChildID = firstNullElement != null ? firstNullElement.ID : 0,
             Description = p.Description,
             SubDescription = firstNullElement!= null ? firstNullElement.Description
                                                      : String.Empty,
             ConditionalCount = g.Count(x => x.Condition != null)
          };
