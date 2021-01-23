    public class DateTimeDayOfYearPropertyHqlGenerator : NHibernate.Linq.Functions.BaseHqlGeneratorForProperty
    {
        public DateTimeDayOfYearPropertyHqlGenerator()
        {
            SupportedProperties = new[]
                {
                    ReflectionHelper.GetProperty((DateTime x) => x.DayOfYear)
                };
        }
        public override NHibernate.Hql.Ast.HqlTreeNode BuildHql(MemberInfo member, Expression expression, NHibernate.Hql.Ast.HqlTreeBuilder treeBuilder, NHibernate.Linq.Visitors.IHqlExpressionVisitor visitor)
        {
            return treeBuilder.MethodCall("dayofyear", visitor.Visit(expression).AsExpression());
        }
    }
