    public static Expression For(ParameterExpression loopVar, Expression initValue, Expression condition, Expression increment, Expression loopContent)
    {
        var initAssign = Expression.Assign(loopVar, initValue);
        var breakLabel = Expression.Label("LoopBreak");
        var loop = Expression.Block(new[] { loopVar },
            initAssign,
            Expression.Loop(
                Expression.IfThenElse(
                    condition,
                    Expression.Block(
                        loopContent,
                        increment
                    ),
                    Expression.Break(breakLabel)
                ),
            breakLabel)
        );
        return loop;
    }
