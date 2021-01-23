    public static Expression<Func<TModel, TProperty>> GenerateModelExpression<TModel, TProperty>(string filter, string select)
    {
         ParameterExpression param = Expression.Parameter(typeof(TModel), "m");
         var body = Expression.Equal(Expression.Property(param, typeof(TModel).GetProperty(filter))
          , Expression.Constant(select));
         return Expression.Lambda<Func<TModel, TProperty>>(body, param);
    }
