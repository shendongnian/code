    using System.Linq.Expressions;
    
    ...
    if(index.GetType().IsAssignableFrom(asset.GetType())) return; // This will prevent an InvlaidCatException
    var param = Expression.Parameter(asset.GetType());
    var exp = Expression
        .Convert(
            param,
            index.GetType());
    var del = Expression.Lambda(exp, param).Compile();
    var val = del.DynamicInvoke(index);
