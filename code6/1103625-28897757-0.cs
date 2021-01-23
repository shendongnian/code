    /// <summary>
    /// Extension methods that try to execute a IQuerable&lt;T&gt; query
    /// on a provider that doesn't support some methods. The part that can
    /// be executed on the provider is executed there, the other part is
    /// executed locally.
    /// 
    /// Note that it **won't** play nice with the Object Tracking!
    /// 
    /// Not suitable for programmers under 5 years (of experience)!
    /// Dangerous if inhaled or executed.
    /// </summary>
    public static class SafeQueryable {
        public class SafeQueryableInner<T> : IEnumerable<T> {
            public readonly IQueryable<T> Query;
            public IEnumerable<T> InnerEnumerable { get; protected set; }
            public SafeQueryableInner(IQueryable<T> query) {
                Query = query;
            }
            public IEnumerator<T> GetEnumerator() {
                if (InnerEnumerable == null) {
                    InnerEnumerable = CreateEnumerable();
                }
                return InnerEnumerable.GetEnumerator();
            }
            IEnumerator IEnumerable.GetEnumerator() {
                return GetEnumerator();
            }
            private IEnumerable<T> CreateEnumerable() {
                try {
                    IEnumerable<T> enumerable = Query.AsEnumerable();
                    // The NotSupportedException happens when the GetEnumerator is 
                    // called
                    IEnumerator<T> enumerator = enumerable.GetEnumerator();
                    // SUCCESS :-)
                    return new FakeEnumerable<T>(enumerator, enumerable);
                } catch (NotSupportedException exception) {
                    // TODO Log this "primary" exception. It will help you to optimize the query
                    // FAILURE :-(
                    MethodInfo createEnumeratorMethod = typeof(SafeQueryableInner<T>).GetMethod("CreateSplittedEnumerable", BindingFlags.Public | BindingFlags.Instance);
                    MethodCallExpression call;
                    Expression innerExpression = Query.Expression;
                    while ((call = innerExpression as MethodCallExpression) != null && call.Arguments.Count > 0 && (innerExpression = call.Arguments[0] as Expression) != null) {
                        try {
                            // We use reflection here, because CreateEnumerator was easier to build with Generics
                            IEnumerable<T> enumerable = (IEnumerable<T>)createEnumeratorMethod.MakeGenericMethod(innerExpression.Type.GetGenericArguments()[0]).Invoke(this, new object[] { call, innerExpression });
                            return enumerable;
                        } catch (TargetInvocationException ex) {
                            if (!(ex.InnerException is NotSupportedException)) {
                                throw;
                            }
                        }
                    }
                    throw;
                }
            }
            public IEnumerable<T> CreateSplittedEnumerable<TInner>(MethodCallExpression call, Expression innerExpression) {
                IEnumerable<TInner> enumerable = Query.Provider.CreateQuery<TInner>(innerExpression);
                // We need to ask for the GetEnumerator to be able to check the query
                // This call will throw if the LINQ-to-SQL can't produce the query
                IEnumerator<TInner> enumerator = enumerable.GetEnumerator();
                // Success!
                // We transform back the enumerator to an enumerable
                IEnumerable<TInner> enumerable2 = new FakeEnumerable<TInner>(enumerator, enumerable);
                // "Quick-n-dirty". We use a fake Queryable. The "right" way would probably be 
                // transform all the outer query from IQueryable.Method<T> to IEnumerable.Method<T>
                // Too much long :)
                // Note that this Queryable is executed in "local" (the AsQueryable<T> method is nearly
                // useless... The second time in my life I was able to use it for something)
                IQueryable<TInner> queryable = Queryable.AsQueryable(enumerable2);
                // We rebuild a new expression by changing the "old" inner parameter
                // of the MethodCallExpression with the queryable we just
                // built
                Expression expression2 = new SimpleExpressionReplacer { Call = call, Queryable = queryable }.Visit(Query.Expression);
                // We "execute" locally the whole query through a second
                // "outer" instance of the EnumerableQuery (this class is
                // the class that "implements" the "fake-magic" of AsQueryable)
                EnumerableQuery<T> query2 = new EnumerableQuery<T>(expression2);
                
                // And we return an enumerator to it
                return query2.AsEnumerable();
            }
            /// <summary>
            /// A fake enumerator that "caches" in advance the first enumerator
            /// and if requested for a second enumerator creates it from an
            /// enumerable
            /// </summary>
            /// <typeparam name="T"></typeparam>
            public class FakeEnumerable<T> : IEnumerable<T> {
                public IEnumerable<T> Enumerable { get; set; }
                private IEnumerator<T> Enumerator { get; set; }
                /// <summary>
                /// We already have a enumerator that we can return when asked (called enumerator). 
                /// If asked for a second enumerator, we build it from the enumerable
                /// </summary>
                /// <param name="enumerator"></param>
                /// <param name="enumerable"></param>
                public FakeEnumerable(IEnumerator<T> enumerator, IEnumerable<T> enumerable) {
                    Enumerable = enumerable;
                    Enumerator = enumerator;
                }
                public IEnumerator<T> GetEnumerator() {
                    if (Enumerator == null) {
                        return Enumerable.GetEnumerator();
                    }
                    IEnumerator<T> enumerator = Enumerator;
                    Enumerator = null;
                    return enumerator;
                }
                IEnumerator IEnumerable.GetEnumerator() {
                    return GetEnumerator();
                }
            }
            /// <summary>
            /// A simple expression visitor to replace the first parameter
            /// of a MethodCall (the IQueryable&lt;X&gt;
            /// </summary>
            public class SimpleExpressionReplacer : ExpressionVisitor {
                public MethodCallExpression Call { get; set; }
                public object Queryable { get; set; }
                protected override Expression VisitMethodCall(MethodCallExpression node) {
                    if (node == Call) {
                        var arguments = node.Arguments.ToArray();
                        arguments[0] = Expression.Constant(Queryable);
                        return Expression.Call(node.Object, node.Method, arguments);
                    }
                    return base.VisitMethodCall(node);
                }
            }
        }
        public static IEnumerable<TElement> AsSafeEnumerable<TElement>(this IQueryable<TElement> query) {
            return new SafeQueryableInner<TElement>(query);
        }
        public static List<TElement> ToSafeList<TElement>(this IQueryable<TElement> query) {
            return query.AsSafeEnumerable().ToList();
        }
        public static TElement[] ToSafeArray<TElement>(this IQueryable<TElement> query) {
            return query.AsSafeEnumerable().ToArray();
        }
        public static TElement SafeFirst<TElement>(this IQueryable<TElement> query) {
            return query.AsSafeEnumerable().First();
        }
        public static TElement SafeFirst<TElement>(this IQueryable<TElement> query, Expression<Func<TElement, bool>> predicate) {
            return query.Where(predicate).AsSafeEnumerable().First();
        }
        public static TElement SafeFirst<TElement>(this IQueryable<TElement> query, Func<TElement, bool> predicate) {
            return query.AsSafeEnumerable().First(predicate);
        }
    }
