    public IQueryable<T> FindBy<TKey>(Expression<Func<T,TKey>> memberExpression, object value)
    {
        var parameterVisitor = new ParameterVisitor(memberExpression);
        var parameter = parameterVisitor.Parameter;
        var constant = Expression.Constant(value);
        var equal = Expression.Equal(memberExpression,constant);
        var predicate = Expression.Lambda(equal, parameter);
        return context.Value.Users.Where(predicate);
    }
    public class ParameterVisitor : ExpressionVisitor
    {
       public ParameterExpression Parameter { get;set;}
       public ParameterVisitor(Expression expr)
       {
           this.Visit(expr);
       }
    
       protected override VisitParameter(ParameterExpression parameter)
       {
            Parameter = parameter;
            return parameter;
        }
      
    }
