     internal class QueryReflectionMethods
        {
            internal static System.Reflection.MethodInfo Enumerable_Select = typeof(Enumerable).GetMethods().First(x => x.Name == "Select" && x.GetParameters().Length == 2);
            internal static System.Reflection.MethodInfo Enumerable_DefaultIfEmpty = typeof(Enumerable).GetMethods().First(x => x.Name == "DefaultIfEmpty" && x.GetParameters().Length == 1);
    
            internal static System.Reflection.MethodInfo Queryable_SelectMany = typeof(Queryable).GetMethods().Where(x => x.Name == "SelectMany" && x.GetParameters().Length == 3).OrderBy(x => x.ToString().Length).First();
            internal static System.Reflection.MethodInfo Queryable_Where = typeof(Queryable).GetMethods().First(x => x.Name == "Where" && x.GetParameters().Length == 2);
            internal static System.Reflection.MethodInfo Queryable_GroupJoin = typeof(Queryable).GetMethods().First(x => x.Name == "GroupJoin" && x.GetParameters().Length == 5);
            internal static System.Reflection.MethodInfo Queryable_Join = typeof(Queryable).GetMethods(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public).First(c => c.Name == "Join");
            internal static System.Reflection.MethodInfo Queryable_Select = typeof(Queryable).GetMethods().First(x => x.Name == "Select" && x.GetParameters().Length == 2);
    
    
    
            public static IQueryable<TResult> CreateLeftOuterJoin<TOuter, TInner, TKey, TResult>(
                       IQueryable<TOuter> outer,
                       IQueryable<TInner> inner,
                       Expression<Func<TOuter, TKey>> outerKeySelector,
                       Expression<Func<TInner, TKey>> innerKeySelector,
                       Expression<Func<TOuter, TInner, TResult>> resultSelector)
            { 
                 
                var keyValuePairHolderWithGroup = typeof(KeyValuePairHolder<,>).MakeGenericType(
                    typeof(TOuter),
                    typeof(IEnumerable<>).MakeGenericType(
                        typeof(TInner)
                        )
                    );
                var paramOuter = Expression.Parameter(typeof(TOuter));
                var paramInner = Expression.Parameter(typeof(IEnumerable<TInner>));
                var groupJoin =
                    Queryable_GroupJoin.MakeGenericMethod(typeof(TOuter), typeof(TInner), typeof(TKey), keyValuePairHolderWithGroup)
                    .Invoke(
                        "ThisArgumentIsIgnoredForStaticMethods",
                        new object[]{
                        outer,
                        inner,
                        outerKeySelector,
                        innerKeySelector,
                        Expression.Lambda(
                            Expression.MemberInit(
                                Expression.New(keyValuePairHolderWithGroup), 
                                Expression.Bind(
                                    keyValuePairHolderWithGroup.GetMember("Item1").Single(),  
                                    paramOuter
                                    ), 
                                Expression.Bind(
                                    keyValuePairHolderWithGroup.GetMember("Item2").Single(), 
                                    paramInner
                                    )
                                ),
                            paramOuter, 
                            paramInner
                            )
                        }
                    );
                  
             
                var paramGroup = Expression.Parameter(keyValuePairHolderWithGroup);
                Expression collectionSelector = Expression.Lambda(                    
                                Expression.Call(
                                        null,
                                        Enumerable_DefaultIfEmpty.MakeGenericMethod(typeof(TInner)),
                                        Expression.MakeMemberAccess(paramGroup, keyValuePairHolderWithGroup.GetProperty("Item2"))) 
                                ,
                                paramGroup
                            );
    
                Expression newResultSelector = new ResultSelectorRewriter<TOuter, TInner, TResult>(resultSelector).CombinedExpression;
    
    
                var selectMany1Result =
                    Queryable_SelectMany.MakeGenericMethod(keyValuePairHolderWithGroup, typeof(TInner), typeof(TResult))
                    .Invoke(
                        "ThisArgumentIsIgnoredForStaticMethods", new object[]{
                            groupJoin,
                            collectionSelector,
                            newResultSelector
                        }
                    );
                return (IQueryable<TResult>)selectMany1Result;
            }
        }
