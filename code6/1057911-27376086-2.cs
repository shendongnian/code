    using System;
    using System.Linq;
    using System.Linq.Expressions;
    public static IQueryable<T> WhereLessOld<T>(this IQueryable<T> source, DateTime oldDate)
        where T : IDate
    {
        var param = Expression.Parameter(typeof(T));
        var filterExpression =
            Expression.And(
                Expression.Not(Expression.Property(param, "IsDeleted")),
                Expression.And(
                    Expression.GreaterThan(
                        Expression.Property(param, "DateChanged"),
                        Expression.Constant(oldDate)
                    ),
                    Expression.LessThan(
                        Expression.Property(param, "DateChanged"),
                        Expression.Constant(oldDate)
                    )
                )
            );
        var delegateExpression = Expression.Lambda<Func<T, bool>>(filterExpression, param);
        return source.Where(delegateExpression);
    }
