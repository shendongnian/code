    var tryGetMember =
        Expression.Block(
            new[] { result },
            Expression.Condition(
                Expression.Equal(
                    Expression.Call(
                        proxyParameter, tryGetMemberMethod, parent,
                        Expression.Constant(propertyName), result),
                    Expression.Constant(true)),
                result,
                Expression.Throw(
                    Expression.Constant(new MissingMemberException(propertyName)),
                    typeof(object))));
