    public static class Helper
    {
        public static List<string> ToPropertiesArray(params System.Linq.Expressions.Expression<Func<object>>[] exprs)
        {
            return exprs.Select(expr => ((expr.Body as System.Linq.Expressions.UnaryExpression).Operand
                                                    as System.Linq.Expressions.MemberExpression).Member.Name)
                                        .ToList();
        }
    }
