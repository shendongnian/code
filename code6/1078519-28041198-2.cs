    foreach (T inputRecord in input)
    {
        object fieldObject = fieldDelegate.Invoke(inputRecord);
        ParameterExpression p = fieldExpression.Parameters.First();
        // Equivalent to x => x.Field == fieldObject
        Expression<Func<T, bool>> predicate = Expression.Lambda<Func<T, bool>>(
            // input.Field == fieldObject
            Expression.Equal(
                // input.Field
                fieldExpression.Body,
                // constant from fieldObject
                Expression.Constant(fieldObject)
            ),
            new []{ p }
        );
        T dataRecord = dbSet.SingleOrDefault(predicate);
        if (dataRecord != null)
        {
            inputRecord.CreatedOn = dataRecord.CreatedOn;
        }
    }
