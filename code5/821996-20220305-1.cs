    var body = EnabledPropertySelector.Body as BinaryExpression;
    var left = body.Left as PropertyExpression;
    var outerMemberName = left.Member.Name;
    var innerMemberName = (left.Expression as PropertyExpression).Member.Name
    VisibilityPropertyName = innerMemberName + "." + outerMemberName;
    var right = body.Right as PropertyExpression;
    var rightValueDelegate = Expression.Lambda<Func<object>>(right).Compile();
    VisibilityPropertyValue = rightValueDelegate();
