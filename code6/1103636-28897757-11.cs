    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    /// <summary>
    /// v0.5 Codename: Armed and Dangerous
    /// 
    /// (previous version v0.1 Codename: Running with Scissors: http://pastebin.com/6qLs8TPt)
    /// (previous version v0.2 Codename: Lost in Space: lost in space :-) )
    /// (previous version v0.3 Codename: Playing with Fire: http://pastebin.com/pRbKt1Z2)
    /// (previous version v0.4 Codename: Crossing without Looking: http://pastebin.com/yEhc9vjg)
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
    /// Minimal support for EF.
    /// 
    /// Note that this **won't** play nice with the Object Tracking!
    ///
    /// Not suitable for programmers under 5 years (of experience)!
    /// Dangerous if inhaled or executed.
    /// </summary>
    public static class SafeQueryable
    {
        /// <summary>
        /// Optional logger to log the queries that are "corrected. Note that
        /// there is no "strong guarantee" that the IQueriable (that is also 
        /// an IQueryProvider) is executing its (as in IQueriable.Expression)
        /// Expression, so an explicit Expression parameter is passed. This
        /// because the IQueryProvider.Execute method receives an explicit
        /// expression parameter. Clearly there is a "weak guarantee" that
        /// unless you do "strange things" this won't happen :-)
        /// </summary>
        public static Action<IQueryable, Expression, NotSupportedException> Logger { get; set; }
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
        protected static readonly FieldInfo StackTraceStringField = typeof(Exception).GetField("_stackTraceString", BindingFlags.Instance | BindingFlags.NonPublic);
        // The query. Note that it can be "transformed" to a "safe" version
        // of itself. When it happens, IsSafe becomes true
        public IQueryable<T> Query { get; protected set; }
        // IsSafe means that the query has been "corrected" if necessary and
        // won't throw a NotSupportedException
        protected bool IsSafe { get; set; }
        // Logging of the "main" NotSupportedException.
        public NotSupportedException Exception { get; protected set; }
        public SafeQueryable(IQueryable<T> query)
        {
            Query = query;
        }
        /* IQueryable<T> */
        public IEnumerator<T> GetEnumerator()
        {
            if (IsSafe)
            {
                return Query.GetEnumerator();
            }
            return new SafeEnumerator(this);
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
        // Gets the T of IQueryablelt;T&gt;
        protected static Type GetIQueryableTypeArgument(Type type)
        {
            IEnumerable<Type> interfaces = type.IsInterface ?
                new[] { type }.Concat(type.GetInterfaces()) :
                type.GetInterfaces();
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
            if (IsSafe && Query.Expression == expression)
            {
                TResult result = Query.Provider.Execute<TResult>(expression);
                return result;
            }
            try
            {
                // Note that thanks to how everything knits together, if you
                // call query1.First(); query1.First(); the second call will
                // get to use the query cached by the first one (technically
                // the cached query will be only the "query1" part)
                // We try executing it directly
                TResult result = Query.Provider.Execute<TResult>(expression);
                // Success!
                if (!IsSafe && CanCache(expression, true))
                {
                    IsSafe = true;
                }
                return result;
            }
            catch (NotSupportedException e1)
            {
                // Clearly there was a NotSupportedException :-)
                Tuple<IEnumerator<T>, bool, TResult> result = HandleEnumerationFailure<TResult>(e1, expression, true);
                if (result == null)
                {
                    throw;
                }
                // Success!
                return result.Item3;
            }
        }
        // Is used both indirectly by GetEnumerator() and by Execute<>.
        // The returned Tuple<,,> has the first two elements that are valid
        // when used by the GetEnumerator() and the last that is valid
        // when used by Execute<>.
        protected Tuple<IEnumerator<T>, bool, TResult> HandleEnumerationFailure<TResult>(NotSupportedException e1, Expression expression, bool singleResult)
        {
            // We "augment" the exception with the full stack trace
            AugmentStackTrace(e1, 3);
            if (SafeQueryable.Logger != null)
            {
                SafeQueryable.Logger(this, expression, e1);
            }
            // We save this first exception
            Exception = e1;
            {
                var query = Query;
                MethodInfo executeSplittedMethod = typeof(SafeQueryable<T>).GetMethod("ExecuteSplitted", BindingFlags.Instance | BindingFlags.NonPublic);
                MethodCallExpression call;
                Expression innerExpression = expression;
                Type iqueryableArgument;
                // We want to check that there is a MethodCallExpression with 
                // at least one argument, and that argument is an Expression
                // of type IQueryable<iqueryableArgument>, and we save the
                // iqueryableArgument
                while ((call = innerExpression as MethodCallExpression) != null &&
                    call.Arguments.Count > 0 &&
                    (innerExpression = call.Arguments[0] as Expression) != null &&
                    (iqueryableArgument = GetIQueryableTypeArgument(innerExpression.Type)) != null)
                {
                    try
                    {
                        Tuple<IEnumerator<T>, bool, TResult> result2 = (Tuple<IEnumerator<T>, bool, TResult>)executeSplittedMethod.MakeGenericMethod(iqueryableArgument, typeof(TResult)).Invoke(this, new object[] { expression, call, innerExpression, singleResult });
                        return result2;
                    }
                    catch (TargetInvocationException e2)
                    {
                        if (!(e2.InnerException is NotSupportedException))
                        {
                            throw;
                        }
                    }
                }
                return null;
            }
        }
        // Is used both indirectly by GetEnumerator() and by Execute<>.
        // The returned Tuple<,,> has the first two elements that are valid
        // when used by the GetEnumerator() and the last that is valid
        // when used by Execute<>.
        protected Tuple<IEnumerator<T>, bool, TResult> ExecuteSplitted<TInner, TResult>(Expression expression, MethodCallExpression call, Expression innerExpression, bool singleResult)
        {
            // The NotSupportedException should happen here
            IQueryable<TInner> innerQueryable = Query.Provider.CreateQuery<TInner>(innerExpression);
            // We try executing it directly
            IEnumerator<TInner> innerEnumerator = innerQueryable.GetEnumerator();
            bool moveNextSuccess = innerEnumerator.MoveNext();
            IEnumerator<T> enumerator;
            TResult singleResultValue;
            // Success!
            {
                // Now we wrap the partially used enumerator in an
                // EnumerableFromStartedEnumerator
                IEnumerable<TInner> innerEnumerable = new EnumerableFromStartedEnumerator<TInner>(innerEnumerator, moveNextSuccess, innerQueryable);
                // Then we apply an AsQueryable, that does some magic
                // to make the query appear to be a Queryable
                IQueryable<TInner> innerEnumerableAsQueryable = Queryable.AsQueryable(innerEnumerable);
                // We rebuild a new expression by changing the "old" 
                // inner parameter of the MethodCallExpression with the 
                // queryable we just built
                var arguments = call.Arguments.ToArray();
                arguments[0] = Expression.Constant(innerEnumerableAsQueryable);
                MethodCallExpression call2 = Expression.Call(call.Object, call.Method, arguments);
                Expression expressionWithFake = new SimpleExpressionReplacer(call, call2).Visit(expression);
                // We "execute" locally the whole query through a second 
                // "outer" instance of the EnumerableQuery (this class is 
                // the class that "implements" the "fake-magic" of 
                // AsQueryable)
                IQueryable<T> queryable = new EnumerableQuery<T>(expressionWithFake);
                if (singleResult)
                {
                    enumerator = null;
                    moveNextSuccess = false;
                    singleResultValue = queryable.Provider.Execute<TResult>(queryable.Expression);
                }
                else
                {
                    enumerator = queryable.GetEnumerator();
                    moveNextSuccess = enumerator.MoveNext();
                    singleResultValue = default(TResult);
                }
            }
            // We could enter here with a new query from Execute<>(),
            // with IsSafe == true . It would be useless to try to cache
            // that query.
            if (!IsSafe && CanCache(expression, singleResult))
            {
                Stopwatch sw = Stopwatch.StartNew();
                // We redo the same things to create a second copy of
                // the query that is "complete", not partially 
                // enumerated. This second copy will be cached in the
                // SafeQueryable<T>.
                // Note that forcing the Queryable.AsQueryable to not
                // "recast" the query to the original IQueryable<T> is
                // quite complex :-) We have to 
                // .AsEnumerable().Select(x => x) .
                IEnumerable<TInner> innerEnumerable = innerQueryable.AsEnumerable().Select(x => x);
                IQueryable<TInner> innerEnumerableAsQueryable = Queryable.AsQueryable(innerEnumerable);
                // Note that we cache the SafeQueryable<>.Expression!
                var arguments = call.Arguments.ToArray();
                arguments[0] = Expression.Constant(innerEnumerableAsQueryable);
                MethodCallExpression call2 = Expression.Call(call.Object, call.Method, arguments);
                Expression expressionWithFake = new SimpleExpressionReplacer(call, call2).Visit(Expression);
                IQueryable<T> queryable = new EnumerableQuery<T>(expressionWithFake);
                // Now the SafeQueryable<T> has a query that *just works*
                Query = queryable;
                IsSafe = true;
                sw.Stop();
                Console.WriteLine(sw.ElapsedTicks);
            }
            return Tuple.Create(enumerator, moveNextSuccess, singleResultValue);
        }
        protected bool CanCache(Expression expression, bool singleResult)
        {
            // GetEnumerator() doesn't permit changing the query
            if (!singleResult)
            {
                return true;
            }
            // The expression is equal to the one in Query.Expression
            // (should be very rare!)
            if (Query.Expression == expression)
            {
                return true;
            }
            MethodCallExpression call;
            Expression innerExpression = expression;
            Type iqueryableArgument;
            // We walk back the expression to see if a smaller part of it is
            // the "original" Query.Expression . This happens for example 
            // when one of the operators that returns a single value 
            // (.First(), .FirstOrDefault(), .Single(), .SingleOrDefault(),
            // .Any(), .All()., .Min(), .Max(), ...) are used.
            while ((call = innerExpression as MethodCallExpression) != null &&
                call.Arguments.Count > 0 &&
                (innerExpression = call.Arguments[0] as Expression) != null &&
                (iqueryableArgument = GetIQueryableTypeArgument(innerExpression.Type)) != null)
            {
                if (Query.Expression == innerExpression)
                {
                    return true;
                }
            }
            return false;
        }
        // The StackTrace of an Exception "stops" at the catch. This method
        // "augments" it to include the full stack trace.
        protected static void AugmentStackTrace(Exception e, int skipFrames = 2)
        {
            // Playing with a private field here. Don't do it at home :-)
            // If not present, do nothing.
            if (StackTraceStringField == null)
            {
                return;
            }
            string stack1 = e.StackTrace;
            string stack2 = new StackTrace(skipFrames, true).ToString();
            string stack3 = stack1 + stack2;
            StackTraceStringField.SetValue(e, stack3);
        }
        /* Utility classes */
        // An IEnumerator<T> that applies the AsSafe() paradigm, knowing that
        // normally the exception happens only on the first MoveFirst().
        protected class SafeEnumerator : IEnumerator<T>
        {
            protected readonly SafeQueryable<T> SafeQueryable_;
            protected IEnumerator<T> Enumerator { get; set; }
            public SafeEnumerator(SafeQueryable<T> safeQueryable)
            {
                SafeQueryable_ = safeQueryable;
            }
            public T Current
            {
                get
                {
                    return Enumerator != null ? Enumerator.Current : default(T);
                }
            }
            public void Dispose()
            {
                if (Enumerator != null)
                {
                    Enumerator.Dispose();
                }
            }
            object IEnumerator.Current
            {
                get { return Current; }
            }
            public bool MoveNext()
            {
                // We handle exceptions only on first MoveNext()
                if (Enumerator != null)
                {
                    return Enumerator.MoveNext();
                }
                try
                {
                    // We try executing it directly
                    Enumerator = SafeQueryable_.Query.GetEnumerator();
                    bool result = Enumerator.MoveNext();
                    // Success!
                    SafeQueryable_.IsSafe = true;
                    return result;
                }
                catch (NotSupportedException e1)
                {
                    // Clearly there was a NotSupportedException :-)
                    Tuple<IEnumerator<T>, bool, T> result = SafeQueryable_.HandleEnumerationFailure<T>(e1, SafeQueryable_.Query.Expression, false);
                    if (result == null)
                    {
                        throw;
                    }
                    Enumerator = result.Item1;
                    return result.Item2;
                }
            }
            public void Reset()
            {
                if (Enumerator != null)
                {
                    Enumerator.Reset();
                }
            }
        }
    }
    // A simple expression visitor to replace some nodes of an expression 
    // with some other nodes
    public class SimpleExpressionReplacer : ExpressionVisitor
    {
        public readonly Dictionary<Expression, Expression> Replaces;
        public SimpleExpressionReplacer(Dictionary<Expression, Expression> replaces)
        {
            Replaces = replaces;
        }
        public SimpleExpressionReplacer(IEnumerable<Expression> from, IEnumerable<Expression> to)
        {
            Replaces = new Dictionary<Expression, Expression>();
            using (var enu1 = from.GetEnumerator())
            using (var enu2 = to.GetEnumerator())
            {
                while (true)
                {
                    bool res1 = enu1.MoveNext();
                    bool res2 = enu2.MoveNext();
                    if (!res1 || !res2)
                    {
                        if (!res1 && !res2)
                        {
                            break;
                        }
                        if (!res1)
                        {
                            throw new ArgumentException("from shorter");
                        }
                        throw new ArgumentException("to shorter");
                    }
                    Replaces.Add(enu1.Current, enu2.Current);
                }
            }
        }
        public SimpleExpressionReplacer(Expression from, Expression to)
        {
            Replaces = new Dictionary<Expression, Expression> { { from, to } };
        }
        public override Expression Visit(Expression node)
        {
            Expression to;
            if (node != null && Replaces.TryGetValue(node, out to))
            {
                return base.Visit(to);
            }
            return base.Visit(node);
        }
    }
    // Simple IEnumerable<T> that "uses" an IEnumerator<T> that has
    // already received a MoveNext(). "eats" the first MoveNext() 
    // received, then continues normally. For shortness, both IEnumerable<T>
    // and IEnumerator<T> are implemented by the same class. Note that if a
    // second call to GetEnumerator() is done, the "real" IEnumerator<T> will
    // be returned, not this proxy implementation.
    public class EnumerableFromStartedEnumerator<T> : IEnumerable<T>, IEnumerator<T>
    {
        public readonly IEnumerator<T> Enumerator;
        public readonly IEnumerable<T> Enumerable;
        // Received by creator. Return value of MoveNext() done by caller
        protected bool FirstMoveNextSuccessful { get; set; }
        // The Enumerator can be "used" only once, then a new enumerator
        // can be requested by Enumerable.GetEnumerator() 
        // (default = false)
        protected bool Used { get; set; }
        // The first MoveNext() has been already done (default = false)
        protected bool DoneMoveNext { get; set; }
        public EnumerableFromStartedEnumerator(IEnumerator<T> enumerator, bool firstMoveNextSuccessful, IEnumerable<T> enumerable)
        {
            Enumerator = enumerator;
            FirstMoveNextSuccessful = firstMoveNextSuccessful;
            Enumerable = enumerable;
        }
        public IEnumerator<T> GetEnumerator()
        {
            if (Used)
            {
                return Enumerable.GetEnumerator();
            }
            Used = true;
            return this;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public T Current
        {
            get
            {
                // There are various school of though on what should
                // happens if called before the first MoveNext() or
                // after a MoveNext() returns false. We follow the 
                // "return default(TInner)" school of thought for the
                // before first MoveNext() and the "whatever the 
                // Enumerator wants" for the after a MoveNext() returns
                // false
                if (!DoneMoveNext)
                {
                    return default(T);
                }
                return Enumerator.Current;
            }
        }
        public void Dispose()
        {
            Enumerator.Dispose();
        }
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
        public bool MoveNext()
        {
            if (!DoneMoveNext)
            {
                DoneMoveNext = true;
                return FirstMoveNextSuccessful;
            }
            return Enumerator.MoveNext();
        }
        public void Reset()
        {
            // This will 99% throw :-) Not our problem.
            Enumerator.Reset();
            // So it is improbable we will arrive here
            DoneMoveNext = true;
        }
    }
