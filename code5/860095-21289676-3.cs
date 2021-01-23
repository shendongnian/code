    public static IQueryable<T> IsBetween<T>(this IQueryable<T> query, Expression<Func<T, DateTime>> selector, DateTime start, DateTime end)
    {
        //Record the start time and end time and turn them in to constants to be passed in to the query.
        //There may be a better way to pass them as parameters instead of constants but I don't have the skill with expression trees to know how to do it.
        var startTime = Expression.Constant(start);
        var endTime = Expression.Constant(end);
        //We get the body of the expression that was passed in that selects the DateTime column in the row for us.
        var selectorBody = selector.Body;
        //We need to pass along the parametres from that original selector.
        var selectorParameters = selector.Parameters;
        // Represents the "date >= start"
        var startCompare = Expression.GreaterThanOrEqual(selectorBody, startTime);
        // Represents the "date < end"
        var endCompare = Expression.LessThan(selectorBody, endTime);
        // Represents the "&&" between the two statements.
        var combinedExpression = Expression.AndAlso(startCompare, endCompare);
        //Reform the new expression in to a lambada to be passed along to the Where clause.
        var lambada = Expression.Lambda<Func<T, bool>>(combinedExpression, selectorParameters);
        //Perform the filtering and return the filtered query.
        return query.Where(lambada);
    }
