    using System.Data.Entity.Migrations;
    ...
    public static string AddWhenNew<T>(DbContext context,
        Expression<Func<T, object>> identifierExpression, T item) where T : class
    {
        var error = string.Empty;
        context.Set<T>().AddOrUpdate(identifierExpression, item);
        if (context.Entry(item).State != System.Data.Entity.EntityState.Added)
        {
            error = string.Format("{0} '{1}' already exists",
                                  item.GetType().Name,
                                  identifierExpression.Compile()(item));
        }
        return error;
    }
