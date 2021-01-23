    public abstract class GenericApiControllerForIOther<T> : ApiController
        where T : IOther
    {
        public HttpResponseMessage Get(int other)
        {
            var query = QueryFunction(Repository, other);
            return Ok(query.ToList());
        }
        // the generic query expression
        static Expression<Func<IQueryable<T>, int, IQueryable<T>>> QueryExpression =
            (repository, other) => repository.Where(x => x.Other == other);
        // the function built from the generci expression
        static Func<IQueryable<T>, int, IQueryable<T>> queryFunction = null;
        static Func<IQueryable<T>, int, IQueryable<T>> QueryFunction
        {
            get
            {
                if (queryFunction == null)
                {
                    // rebuild a new lambda expression without reference to the IOther type
                    TypeReplacer replacer = new TypeReplacer(typeof(IOther), typeof(T));
                    Expression newExp = replacer.Visit(QueryExpression.Body);
                    Expression<Func<IQueryable<T>, int, IQueryable<T>>> newLambdaExp = Expression.Lambda<Func<IQueryable<T>, int, IQueryable<T>>>(newExp, QueryExpression.Parameters);
                    // newLambdaExp.ToString(): (repository, other) => repository.Where(x => (x.Other == other))
                    // convert the expression to a function
                    queryFunction = newLambdaExp.Compile();
                }
                return queryFunction;
            }
        }
        class TypeReplacer : ExpressionVisitor
        {
            public TypeReplacer(Type oldType, Type newType)
            {
                OldType = oldType;
                NewType = newType;
            }
            Type OldType;
            Type NewType;
            protected override Expression VisitMember(MemberExpression node)
            {
                // replace IOther.Property by T.Property
                MemberInfo memberInfo = node.Member;
                if (memberInfo.DeclaringType == OldType)
                {
                    MemberInfo newMemberInfo = NewType.GetMember(memberInfo.Name).First();
                    return Expression.MakeMemberAccess(Visit(node.Expression), newMemberInfo);
                }
                return base.VisitMember(node);
            }
            protected override Expression VisitUnary(UnaryExpression node)
            {
                // remove the Convert operator
                if (node.NodeType == ExpressionType.Convert
                    && node.Type == OldType
                    && node.Operand.Type == NewType)
                    return node.Operand;
                return base.VisitUnary(node);
            }
        }
    }
