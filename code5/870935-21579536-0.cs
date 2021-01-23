    // using E = System.Linq.Expressions.Expression;
    var item = E.Paramter(typeof(TView));
    var combined = E.Lambda<Func<TView, bool>>(
        E.AndAlso(
            E.Invoke(parentCodeFilterExpression, item), 
            E.Invoke(textFilterExpression, item)),
        item);
