    // Note that we only need the Body!
    Expression pred1 = Expression.OrElse(Expression.OrElse(predicate1.Body, predicate2.Body), predicate3.Body);
    // We change all the predicate2.Parameters[0] to predicate1.Parameters[0] and
    // predicate3.Parameters[0] to predicate1.Parameters[0]
    var replacer = new SimpleExpressionReplacer(
        /* from */ new[] { predicate2.Parameters[0], predicate3.Parameters[0] }, 
        /* to */ new[] { predicate1.Parameters[0], predicate1.Parameters[0] });
    pred1 = replacer.Visit(pred1);
    // We use for the new predicate the predicate1.Parameters[0]
    var pred2 = Expression.Lambda<Func<T, bool>>(pred1, predicate1.Parameters[0]);
    var result = queryable.Where(pred2);
