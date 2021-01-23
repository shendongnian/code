    // using E = System.Linq.Expressions.Expression;
    
    var item = E.Parameter(typeof(TView));
    var combined = E.Lambda<Func<TView, bool>>(
        E.AndAlso(
            E.Invoke(parentCodeFilterExpression, item), 
            E.Invoke(textFilterExpression, item)),
        item);
