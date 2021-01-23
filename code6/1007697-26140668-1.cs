    public class DefaultOrderVisitor : DefaultExpressionVisitor
    {
        public override DbExpression Visit(DbScanExpression expression)
        {
            const string NAMESPACE = "OrderTest";
     
            var type =
                Assembly.GetExecutingAssembly().GetType(string.Format("{0}.{1}", NAMESPACE, expression.Target.Name));
     
            var attribute =
                type.GetCustomAttributes(typeof (DefaultOrderFieldAttribute)).SingleOrDefault() as
                    DefaultOrderFieldAttribute;
     
            if (attribute != null)
                return expression.OrderBy(ex => ex.Property(attribute.FieldName));
     
            return expression;
        }
    }
