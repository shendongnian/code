    /// <summary>
    /// v0.3 Codename: Playing with Fire
    /// 
    /// (previous version v0.1 Codename: Running with Scissors: http://pastebin.com/6qLs8TPt)
    /// 
    /// Support class with an extension method to make "Safe" an IQueryable 
    /// or IQueryable&lt;T&gt;. Safe as "I work for another company, thousand 
    /// of miles from you. I do hope I won't ever buy/need something from 
    /// your company".
    /// The Extension methods wraps a IQueryable in a wrapper that then can
    /// be used to execute a query. If the original Provider doesn't suppport
    /// some methods, the query will be partially executed by the Provider 
    /// and partially executed locally.
    ///
    /// Note that this **won't** play nice with the Object Tracking!
    ///
    /// Not suitable for programmers under 5 years (of experience)!
    /// Dangerous if inhaled or executed.
    /// </summary>
    public static class SafeQueryable
    {
        /// <summary>
        /// Return a "Safe" IQueryable&lt;T&gt;. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IQueryable<T> AsSafe<T>(this IQueryable<T> source)
        {
            if (source is SafeQueryable<T>)
            {
                return source;
            }
            return new SafeQueryable<T>(source);
        }
    }
    /// <summary>
    /// Simple interface useful to collect the Exception, or to recognize
    /// a SafeQueryable&lt;T&gt;.
    /// </summary>
    public interface ISafeQueryable
    {
        NotSupportedException Exception { get; }
    }
    /// <summary>
    /// "Safe" wrapper around a IQueryable&lt;T;&gt;
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SafeQueryable<T> : IOrderedQueryable<T>, IQueryProvider, ISafeQueryable
    {
        public readonly IQueryable<T> Query;
        /// <summary>
        /// Logging of the "main" NotSupportedException.
        /// </summary>
        public NotSupportedException Exception { get; protected set; }
        public SafeQueryable(IQueryable<T> query)
        {
            Query = query;
        }
        /* IQueryable<T> */
        public IEnumerator<T> GetEnumerator()
        {
            return Provider.Execute<IEnumerable<T>>(Expression).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public Type ElementType
        {
            get { return Query.ElementType; }
        }
        public Expression Expression
        {
            get { return Query.Expression; }
        }
        public IQueryProvider Provider
        {
            get { return this; }
        }
        /* IQueryProvider */
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return CreateQueryImpl<TElement>(expression);
        }
        public IQueryable CreateQuery(Expression expression)
        {
            Type iqueryableArgument = GetIQueryableTypeArgument(expression.Type);
            MethodInfo createQueryImplMethod = typeof(SafeQueryable<T>)
                .GetMethod("CreateQueryImpl", BindingFlags.Instance | BindingFlags.NonPublic)
                .MakeGenericMethod(iqueryableArgument);
            return (IQueryable)createQueryImplMethod.Invoke(this, new[] { expression });
        }
        public TResult Execute<TResult>(Expression expression)
        {
            return ExecuteImpl<TResult>(expression);
        }
        public object Execute(Expression expression)
        {
            Type iqueryableArgument = GetIQueryableTypeArgument(expression.Type);
            MethodInfo executeImplMethod = typeof(SafeQueryable<T>)
                .GetMethod("ExecuteImpl", BindingFlags.Instance | BindingFlags.NonPublic)
                .MakeGenericMethod(iqueryableArgument);
            return executeImplMethod.Invoke(this, new[] { expression });
        }
        /* Implementation methods */
        /// <summary>
        /// Gets the T of IQueryablelt;T&gt;
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        protected static Type GetIQueryableTypeArgument(Type type)
        {
            IEnumerable<Type> interfaces = type.IsInterface ? new[] { type }.Concat(type.GetInterfaces()) : type.GetInterfaces();
            Type argument = (from x in interfaces
                             where x.IsGenericType
                             let gt = x.GetGenericTypeDefinition()
                             where gt == typeof(IQueryable<>)
                             select x.GetGenericArguments()[0]).FirstOrDefault();
            return argument;
        }
        protected IQueryable<TElement> CreateQueryImpl<TElement>(Expression expression)
        {
            return new SafeQueryable<TElement>(Query.Provider.CreateQuery<TElement>(expression));
        }
        protected TResult ExecuteImpl<TResult>(Expression expression)
        {
            Exception = null;
            try
            {
                // We try executing it directly
                TResult result = Query.Provider.Execute<TResult>(expression);
                // Success!
                return result;
            }
            catch (NotSupportedException e)
            {
                // Clearly there was a NotSupportedException :-)
                // We save this first exception
                Exception = e;
                // Much easier to call it through reflection.
                // In this way we can pass him some generic types
                MethodInfo executeSplittedMethod = typeof(SafeQueryable<T>).GetMethod("ExecuteSplitted", BindingFlags.Static | BindingFlags.NonPublic);
                MethodCallExpression call;
                Expression innerExpression = expression;
                Type iqueryableArgument;
                // We want to check that there is a MethodCallExpression
                // with at least one argument, and that argument is an Expression
                // of type IQueryable<iqueryableArgument>, and we save the
                // iqueryableArgument
                while ((call = innerExpression as MethodCallExpression) != null &&
                    call.Arguments.Count > 0 &&
                    (innerExpression = call.Arguments[0] as Expression) != null &&
                    (iqueryableArgument = GetIQueryableTypeArgument(innerExpression.Type)) != null)
                {
                    try
                    {
                        TResult result = (TResult)executeSplittedMethod.MakeGenericMethod(iqueryableArgument, typeof(TResult)).Invoke(null, new object[] { Query, expression, call, innerExpression });
                        // Success!
                        return result;
                    }
                    catch (TargetInvocationException ex)
                    {
                        if (!(ex.InnerException is NotSupportedException))
                        {
                            throw;
                        }
                    }
                }
                throw;
            }
        }
        protected static TResult ExecuteSplitted<TInner, TResult>(IQueryable queryable, Expression expression, MethodCallExpression call, Expression innerExpression)
        {
            // We do know that all the "inner" parts of the query return/use
            // IQueryable<> (we checked it when calling this method), 
            // So we can execute them asking for a IEnumerable<>.
            // Only the most external part of the query (the First/Last/Min/Max/...) 
            // can return a non-IQueryable<>, but that one has already been
            // handled and splitted
            // The NotSupportedException should happen here
            IEnumerable<TInner> enumerable = queryable.Provider.Execute<IEnumerable<TInner>>(innerExpression);
            // "Quick-n-dirty". We use a fake Queryable. The "right" way would probably be 
            // transform all the outer query from IQueryable.Method<T> to IEnumerable.Method<T>
            // Too much long, and it's probably what AsQueryable does :-)
            // Note that this Queryable is executed in "local" (the AsQueryable<T> method is 
            // nearlyuseless... The second time in my life I was able to use it for something)
            IQueryable<TInner> fakeQueryable = Queryable.AsQueryable(enumerable);
            // We rebuild a new expression by changing the "old" inner parameter
            // of the MethodCallExpression with the queryable we just
            // built
            Expression expressionWithFake = new SimpleExpressionReplacer { Call = call, Queryable = fakeQueryable }.Visit(expression);
            // We "execute" locally the whole query through a second
            // "outer" instance of the EnumerableQuery (this class is
            // the class that "implements" the "fake-magic" of AsQueryable)
            EnumerableQuery<TResult> fullQueryableWithFake = new EnumerableQuery<TResult>(expressionWithFake);
            TResult result = ((IQueryProvider)fullQueryableWithFake).Execute<TResult>(expressionWithFake);
            return result;
        }
        /// <summary>
        /// A simple expression visitor to replace the first parameter
        /// of a MethodCallExpression (the IQueryable&lt;X&gt;)
        /// </summary>
        protected class SimpleExpressionReplacer : ExpressionVisitor
        {
            public MethodCallExpression Call { get; set; }
            public IQueryable Queryable { get; set; }
            protected override Expression VisitMethodCall(MethodCallExpression node)
            {
                if (node == Call)
                {
                    var arguments = node.Arguments.ToArray();
                    arguments[0] = Expression.Constant(Queryable);
                    return Expression.Call(node.Object, node.Method, arguments);
                }
                return base.VisitMethodCall(node);
            }
        }
    }
