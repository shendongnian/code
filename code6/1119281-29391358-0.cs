    public Expression<Func<LookupFilterItem, string>> PropertyLambda(string propertyName)
        {
            var param = Expression.Parameter(typeof(LookupFilterItem), "lookupItem");
            var propertyExpression = Expression.Property(param, propertyName);
            var returnExpr = Expression.Lambda<Func<LookupFilterItem, string>>(propertyExpression, param);
            return returnExpr;
        }
