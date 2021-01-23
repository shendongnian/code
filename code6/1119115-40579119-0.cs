        public override DbExpression Visit(DbJoinExpression expression)
        {
            //TODO pull these values from attributes etc
            var discriminatorColumn = "AnimalType";
            var discriminatorType = "Cat";
            //if (Attribute.GetCustomAttributes())
            //People
            DbExpressionBinding left = this.VisitExpressionBinding(expression.Left);
            //Unfiltered Animals
            DbExpressionBinding right = this.VisitExpressionBinding(expression.Right);
            // Create the property based on the variable in order to apply the equality
            var discriminatorProperty = DbExpressionBuilder.Property(right.Variable, discriminatorColumn);
            //TODO create type from discriminatorType to match property type eg string, guid, int etc
            var predicateExpression = DbExpressionBuilder.Equal(discriminatorProperty, DbExpression.FromString(discriminatorType));
            //Use existing condition and combine with new condition using And
            var joinCondition = DbExpressionBuilder.And(expression.JoinCondition, predicateExpression);
            DbExpression newExpression = expression;
            //only re-create the join if something changed
            if (!ReferenceEquals(expression.Left, left)
                || !ReferenceEquals(expression.Right, right)
                || !ReferenceEquals(expression.JoinCondition, joinCondition))
            {
                switch (expression.ExpressionKind)
                {
                    case DbExpressionKind.InnerJoin:
                        newExpression = DbExpressionBuilder.InnerJoin(left, right, joinCondition);
                        break;
                    case DbExpressionKind.LeftOuterJoin:
                        newExpression = DbExpressionBuilder.LeftOuterJoin(left, right, joinCondition);
                        break;
                    default:
                        Debug.Assert(
                            expression.ExpressionKind == DbExpressionKind.FullOuterJoin,
                            "DbJoinExpression had ExpressionKind other than InnerJoin, LeftOuterJoin or FullOuterJoin?");
                        newExpression = DbExpressionBuilder.FullOuterJoin(left, right, joinCondition);
                        break;
                }
            }
            return newExpression;
        }
