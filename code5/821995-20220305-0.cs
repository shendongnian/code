    var binaryExpression = EnabledPropertySelector as BinaryExpression;
    var left = binaryExpression.Left as PropertyExpression;
    var outerMemberName = left.Member.Name;
    var innerMemberName = (left.Expression as PropertyExpression).Member.Name
    VisibilityPropertyName = innerMemberName + "." + outerMemberName;
