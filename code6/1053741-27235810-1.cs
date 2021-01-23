        public class Condition
        {
            public string Name { get; set; }
            public string Value { get; set; }
            public string Operator { get; set; }
        }
        public static T FilterBy<T>(this T something, Expression<Func<T, object>> e)
        {
            var conditions = new List<Condition>();
            CheckConditions(conditions, e);
            return (T)Convert.ChangeType(test, typeof(T));
        }
        
        private static void CheckConditions(List<Condition> conditions, Expression<Func<T, object>> e)
        {
            BinaryExpression binaryExpression = 
               (BinaryExpression) ((UnaryExpression) e.Body).Operand;
            if ((e.Body as UnaryExpression).Operand.NodeType == ExpressionType.AndAlso)
            {
                CheckConditions(conditions, binaryExpression.Left);
                CheckConditions(conditions, binaryExpression.Right);
            }
            else
            {
                conditions.Add(GetCondition(binaryExpression));
            }
        }
        private static Condition GetCondition(BinaryExpression e)
        {
            var condition = new Condition();
            condition.Name = ((MemberExpression) binaryExpression.Left).Member.Name;
            condition.Value = binaryExpression
                .Right.GetType().GetProperty("Value")
                .GetValue(binaryExpression.Right).ToString();
            condition.Operator = binaryExpression.NodeType;
            return condition;
        }
