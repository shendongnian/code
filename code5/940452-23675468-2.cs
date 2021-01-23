    private static T GetSingleOrDefault<T>(IEnumerable<T> collection, Expression<Func<T, bool>> predicate)
    {
        try
        {
            return collection.SingleOrDefault(predicate.Compile());
        }
        catch (InvalidOperationException e)
        {
            var message = string.Format(
                "{0} (Collection IEnumerable<{1}> param {2})",
                e.Message,
                typeof(T).Name,
                predicate);
            throw new InvalidOperationException(message);
        }
    }
