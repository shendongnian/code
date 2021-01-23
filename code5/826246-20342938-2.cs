    public static class PropertyHelper
    {
        public static string GetDisplayName<T>(Expression<Func<T, object>> propertyExpression)
        {
            Expression expression;
            if (propertyExpression.Body.NodeType == ExpressionType.Convert)
            {
                expression = ((UnaryExpression)propertyExpression.Body).Operand;
            }
            else
            {
                expression = propertyExpression;
            }
            if (expression.NodeType != ExpressionType.MemberAccess)
            {
                throw new ArgumentException("Must be a property expression.", "propertyExpression");
            }
            var me = (MemberExpression)expression;
            var member = me.Member;
            var att = member.GetCustomAttributes(typeof(DisplayAttribute), false).OfType<DisplayAttribute>().FirstOrDefault();
            if (att != null)
            {
                return att.Name;
            }
            else
            {
                // No attribute found, just use the actual name.
                return member.Name;
            }
        }
        public static string GetDisplayName<T>(this T target, Expression<Func<T, object>> propertyExpression)
        {
            return GetDisplayName<T>(propertyExpression);
        }
    }
