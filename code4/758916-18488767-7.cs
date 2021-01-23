    public static class QueryableEx
    {
        private static readonly ConcurrentDictionary<Type, Dictionary<PropertyInfo, LambdaExpression>> expressions = new ConcurrentDictionary<Type, Dictionary<PropertyInfo, LambdaExpression>>();
    
        public static IQueryable<T> Expand<T>(this IQueryable<T> query)
        {
            var visitor = new QueryableVisitor();
            Expression expression2 = visitor.Visit(query.Expression);
    
            return query.Expression != expression2 ? query.Provider.CreateQuery<T>(expression2) : query;
        }
    
        private static Dictionary<PropertyInfo, LambdaExpression> Get(Type type)
        {
            Dictionary<PropertyInfo, LambdaExpression> dict;
    
            if (expressions.TryGetValue(type, out dict))
            {
                return dict;
            }
    
            var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
    
            dict = new Dictionary<PropertyInfo, LambdaExpression>();
    
            foreach (var prop in props)
            {
                var exp = type.GetMember(prop.Name + "Expression", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static).Where(p => p.MemberType == MemberTypes.Field || p.MemberType == MemberTypes.Property).SingleOrDefault();
    
                if (exp == null)
                {
                    continue;
                }
    
                if (!typeof(LambdaExpression).IsAssignableFrom(exp.MemberType == MemberTypes.Field ? ((FieldInfo)exp).FieldType : ((PropertyInfo)exp).PropertyType))
                {
                    continue;
                }
    
                var lambda = (LambdaExpression)(exp.MemberType == MemberTypes.Field ? ((FieldInfo)exp).GetValue(null) : ((PropertyInfo)exp).GetValue(null, null));
    
                if (prop.PropertyType != lambda.ReturnType)
                {
                    throw new Exception(string.Format("Mismatched return type of Expression of {0}.{1}, {0}.{2}", type.Name, prop.Name, exp.Name));
                }
    
                dict[prop] = lambda;
            }
    
            // We try to save some memory, removing empty dictionaries
            if (dict.Count == 0)
            {
                dict = null;
            }
    
            // There is no problem if multiple threads generate their "versions"
            // of the dict at the same time. They are all equivalent, so the worst
            // case is that some CPU cycles are wasted.
            dict = expressions.GetOrAdd(type, dict);
    
            return dict;
        }
    
        private class SingleParameterReplacer : ExpressionVisitor
        {
            public readonly ParameterExpression From;
            public readonly Expression To;
    
            public SingleParameterReplacer(ParameterExpression from, Expression to)
            {
                this.From = from;
                this.To = to;
            }
    
            protected override Expression VisitParameter(ParameterExpression node)
            {
                return node != this.From ? base.VisitParameter(node) : this.Visit(this.To);
            }
        }
    
        private class QueryableVisitor : ExpressionVisitor
        {
            protected static readonly Assembly MsCorLib = typeof(int).Assembly;
            protected static readonly Assembly Core = typeof(IQueryable).Assembly;
    
            // Used to check for recursion
            protected readonly List<MemberInfo> MembersBeingVisited = new List<MemberInfo>();
    
            protected override Expression VisitMember(MemberExpression node)
            {
                var declaringType = node.Member.DeclaringType;
                var assembly = declaringType.Assembly;
    
                if (assembly != MsCorLib && assembly != Core && node.Member.MemberType == MemberTypes.Property)
                {
                    var dict = QueryableEx.Get(declaringType);
    
                    LambdaExpression lambda;
    
                    if (dict != null && dict.TryGetValue((PropertyInfo)node.Member, out lambda))
                    {
                        // Anti recursion check
                        if (this.MembersBeingVisited.Contains(node.Member))
                        {
                            throw new Exception(string.Format("Recursively visited member. Chain: {0}", string.Join("->", this.MembersBeingVisited.Concat(new[] { node.Member }).Select(p => p.DeclaringType.Name + "." + p.Name))));
                        }
    
                        this.MembersBeingVisited.Add(node.Member);
    
                        // Replace the parameters of the expression with "our" reference
                        var body = new SingleParameterReplacer(lambda.Parameters[0], node.Expression).Visit(lambda.Body);
    
                        Expression exp = this.Visit(body);
    
                        this.MembersBeingVisited.RemoveAt(this.MembersBeingVisited.Count - 1);
    
                        return exp;
                    }
                }
    
                return base.VisitMember(node);
            }
        }
    }
