    // Your switch stays as is
    switch ((StringOperators)SelectedOperator) {
        case StringOperators.Is:
            condition = Expression.Equal(property, value);
            break;
        ...
    }
    // Create null checker property != null
    var nullCheck = Expression.NotEqual(property, Expression.Constant(null));
    // Add null checker in front of the condition using &&
    condition = Expression.AndAlso(nullCheck, condition);
