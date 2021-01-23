        protected override Expression VisitMember(MemberExpression node)
        {            
            //Expression e = base.VisitMember(node); - I've commented this line
            MemberExpression me = node as MemberExpression;
            if (me != null)
            {
                String modelPropertyName = ((PropertyInfo)me.Member).Name;
                ParameterExpression pe = node.Expression as ParameterExpression;
                TModel m = Activator.CreateInstance<TModel>();
                PropertyInfo memberPI = GetEntityProperty(m, modelPropertyName);
                MemberExpression meToReturn = Expression.Property(Expression.Parameter(typeof(TEntity)), memberPI.Name);
                return base.VisitMember(meToReturn); //and changed this line
            }
            else
            {
                return base.VisitMember(node);
            }
        }
