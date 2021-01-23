    public static class FilterExtension
    {
        public class Condition
        {
            public string Name { get; set; }
            public string Value { get; set; }
            public string Operator { get; set; }
        }
        public static T FilterBy<T>(this T something, Expression<Func<T, object>> e)
        {
            var conditions = new List<Condition>();
            BinaryExpression binaryExpression =
           (BinaryExpression)((UnaryExpression)e.Body).Operand;
            CheckConditions(conditions, binaryExpression);
            return (T)Convert.ChangeType(test, typeof(T));
        }
        private static void CheckConditions(List<Condition> conditions, BinaryExpression binaryExpression)
        {
            if (binaryExpression.NodeType == ExpressionType.AndAlso)
            {
                CheckConditions(conditions, binaryExpression.Left as BinaryExpression);
                CheckConditions(conditions, binaryExpression.Right as BinaryExpression);
            }
            else
            {
                conditions.Add(GetCondition(binaryExpression));
            }
        }
        private static Condition GetCondition(BinaryExpression binaryExpression)
        {
            var condition = new Condition();
            condition.Name = ((MemberExpression)binaryExpression.Left).Member.Name;
            condition.Value = binaryExpression
                .Right.GetType().GetProperty("Value")
                .GetValue(binaryExpression.Right, null).ToString();
            condition.Operator = binaryExpression.NodeType.ToString();
            return condition;
        }
    }
