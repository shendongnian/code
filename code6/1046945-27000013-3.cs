    public static class ExpressionExtensions {
      public static T AsPlaceholder<T>(this Expression expression) {
        throw new InvalidOperationException(
          "Expression contains placeholders."
        );
      }
    
      public static Expression FillPlaceholders(this Expression expression) {
        return new PlaceholderExpressionVisitor().Visit(expression);
      }
    }
    
    class PlaceholderExpressionVisitor : ExpressionVisitor {
      protected override Expression VisitMethodCall(MethodCallExpression node) {
        if (
          node.Method.DeclaringType == typeof(ExpressionExtensions) && 
          node.Method.Name == "AsPlaceholder"  // in C# 6, we would use nameof()
        ) {
          return Expression.Lambda<Func<Expression>>(node.Arguments[0]).Compile()();
        } else {
          return base.VisitMethodCall(node);
        }
      }
    }
