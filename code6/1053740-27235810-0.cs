        public static T FilterBy<T>(this T something, Expression<Func<T, object>> e)
        {
            BinaryExpression binaryExpression =
                (BinaryExpression) ((UnaryExpression) e.Body).Operand;
            if ((e.Body as UnaryExpression).Operand.NodeType == ExpressionType.AndAlso)
            {
                var a = (binaryExpression.Left as BinaryExpression);
                var b = (binaryExpression.Right as BinaryExpression);
            }
            else
            {
                string left = ((MemberExpression) binaryExpression.Left).Member.Name;
                string right = binaryExpression
                    .Right.GetType().GetProperty("Value")
                    .GetValue(binaryExpression.Right).ToString();
                ExpressionType @operator = binaryExpression.NodeType;
            }
            return (T)Convert.ChangeType(test, typeof(T));
        }
