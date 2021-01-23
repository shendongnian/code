    public class CrmEntityLogicalName : ExpressionVisitor
        {    
    
            private ReadOnlyCollection<ParameterExpression> parameters;
            private CrmEntityLogicalName(
                ReadOnlyCollection<ParameterExpression> parameters)
            {
                VisitedMembers = new List<MemberInfo>();
                this.parameters = parameters;
            }
    
            protected override Expression VisitMember(MemberExpression node)
            {
                if (parameters.Contains(node.Expression))
                {
                    if (Attribute.IsDefined(node.Member, typeof(AttributeLogicalNameAttribute)))
                    {
                        VisitedMembers.Add(node.Member);
                    }                
                }
                return base.VisitMember(node);
            }
            private List<MemberInfo> VisitedMembers { get; set; }
    
            public static IEnumerable<string> GetLogicalNames<T, TResult>(
                Expression<Func<T, TResult>> lambda)
            {
                var visitor = new CrmEntityLogicalName(lambda.Parameters);
                visitor.Visit(lambda);
    
                return (from entMember in visitor.VisitedMembers select entMember.GetCustomAttributes(typeof (AttributeLogicalNameAttribute), false) 
                            as AttributeLogicalNameAttribute[] into atts where atts != null && atts.Any() select atts[0].LogicalName).ToList();
            }
        }
