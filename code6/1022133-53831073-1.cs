    using LinqKit; // nuget     
       var customField_Ids = customFields?.Select(t => new CustomFieldKey { Id = t.Id, TicketId = t.TicketId }).ToList();
       
        var uniqueIds1 = customField_Ids.Select(cf => cf.Id).Distinct().ToList();
        var uniqueIds2 = customField_Ids.Select(cf => cf.TicketId).Distinct().ToList();
        var predicate = PredicateBuilder.New<CustomFieldKey>(false); //LinqKit
        var lambdas = new List<Expression<Func<CustomFieldKey, bool>>>();
        foreach (var cfKey in customField_Ids)
        {
            var id = uniqueIds1.Where(uid => uid == cfKey.Id).Take(1).ToList();
            var ticketId = uniqueIds2.Where(uid => uid == cfKey.TicketId).Take(1).ToList();
            lambdas.Add(t => id.Contains(t.Id) && ticketId.Contains(t.TicketId));
        }
        predicate = AggregateExtensions.AggregateBalanced(lambdas.ToArray(), (expr1, expr2) =>
         {
             var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
             return Expression.Lambda<Func<CustomFieldKey, bool>>
                   (Expression.OrElse(expr1.Body, invokedExpr), expr1.Parameters);
         });
 
        var modifiedCustomField_Ids = repository.GetTable<CustomFieldLocal>()
             .Select(cf => new CustomFieldKey() { Id = cf.Id, TicketId = cf.TicketId }).Where(predicate).ToArray();
