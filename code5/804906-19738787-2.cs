    QueryOver<Task> subQuery = QueryOver.Of<Task>()
        .Select(
           Projections.GroupProperty(
               Projections.Property<Task>(t => t.OrderId)
           )
         )
         .Where(Restrictions.Gt(Projections.Count<Task>(t => t.OrderId), 1))
         ;
