    /// <summary>
    /// Express an order rule based on property name
    /// </summary>
    public class OrderRule
    {
        public OrderRule(string fieldOrPropertyName, bool descending)
        {
            FieldOrPropertyName = fieldOrPropertyName;
            Descending = descending;
        }
        public string FieldOrPropertyName { get; private set; }
        public bool Descending { get; private set; }
    }
    /// <summary>
    /// Static class holding the OrderByRules extension method
    /// </summary>
    static public class MyLINQExtensions
    {
        /// <summary>
        /// Order <paramref name="dataCollection"/> according to <paramref name="rules"/> sequence
        /// </summary>
        /// <typeparam name="T">Collection item type</typeparam>
        /// <param name="dataCollection">Queryable collection</param>
        /// <param name="rules">Order rules to apply</param>
        /// <returns>Ordered queryable collection</returns>
        public static IOrderedQueryable<T> OrderByRules<T>(this IQueryable<T> dataCollection, IEnumerable<OrderRule> rules)
        {
            if (!rules.Any())
                throw new ArgumentException("Rules list is empty", "rules");
            // apply first rule (special case: use OrderBy operator and not ThenBy)
            OrderRule rule = rules.First();
            MethodInfo orderOperator = rule.Descending ? OrderByDescendingMethodInfo : OrderByMethodInfo;
            IOrderedQueryable<T> orderedDataCollection = OrderByFieldOrPropertyName(dataCollection, orderOperator, rule.FieldOrPropertyName);
            // apply next rules recursivly
            return OrderByRulesRecursivly(orderedDataCollection, rules.Skip(1).ToList());
        }
        static IOrderedQueryable<T> OrderByFieldOrPropertyName<T>(IQueryable<T> dataCollection, MethodInfo orderOperator, string fieldOrPropertyName)
        {
            // member corresponding to fieldOrPropertyName
            MemberInfo memberInfo = typeof(T).GetField(fieldOrPropertyName);
            Type memberType = null;
            if (memberInfo == null)
                memberInfo = typeof(T).GetProperty(fieldOrPropertyName);
            else
                memberType = (memberInfo as FieldInfo).FieldType;
            if (memberInfo == null)
                throw new ArgumentException(String.Format("Field or property '{0}' doesn't exist on type '{1}'", fieldOrPropertyName, typeof(T)));
            else
                memberType = (memberInfo as PropertyInfo).PropertyType;
            // build lambda expression: item => item.fieldName
            ParameterExpression paramExp = Expression.Parameter(typeof(T));
            LambdaExpression keySelectorExp = Expression.Lambda(Expression.MakeMemberAccess(paramExp, memberInfo), paramExp);
            // build concrete MethodInfo from the generic one
            orderOperator = orderOperator.MakeGenericMethod(typeof(T), memberType);
            // invoke method on dataCollection
            return orderOperator.Invoke(null, new object[] {
                dataCollection,
                keySelectorExp
            }) as IOrderedQueryable<T>;
        }
        static IOrderedQueryable<T> OrderByRulesRecursivly<T>(IOrderedQueryable<T> dataCollection, List<OrderRule> rules)
        {
            if (!rules.Any())
                return dataCollection;
            // apply first rule
            OrderRule rule = rules.First();
            MethodInfo orderOperator = rule.Descending ? ThenByDescendingMethodInfo : ThenByMethodInfo;
            IOrderedQueryable<T> orderedDataCollection = OrderByFieldOrPropertyName(dataCollection, orderOperator, rule.FieldOrPropertyName);
            // apply next rules recursivly
            return OrderByRulesRecursivly(orderedDataCollection, rules.Skip(1).ToList());
        }
        /// <summary>
        /// Static constructor. Initialize Reflection informations about Order operators
        /// </summary>
        static MyLINQExtensions()
        {
            // public static IOrderedQueryable<TSource> OrderBy<TSource, TKey>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector);
            OrderByMethodInfo = typeof(Queryable)
                .GetMethods()
                .First(m => m.Name == "OrderBy" && m.GetParameters().Count() == 2);
            // public static IOrderedQueryable<TSource> OrderByDescending<TSource, TKey>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector);
            OrderByDescendingMethodInfo = typeof(Queryable)
                .GetMethods()
                .First(m => m.Name == "OrderByDescending" && m.GetParameters().Count() == 2);
            // public static IOrderedQueryable<TSource> ThenBy<TSource, TKey>(this IOrderedQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector);
            ThenByMethodInfo = typeof(Queryable)
                .GetMethods()
                .First(m => m.Name == "ThenBy" && m.GetParameters().Count() == 2);
            // public static IOrderedQueryable<TSource> ThenByDescending<TSource, TKey>(this IOrderedQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector);
            ThenByDescendingMethodInfo = typeof(Queryable)
                .GetMethods()
                .First(m => m.Name == "ThenByDescending" && m.GetParameters().Count() == 2);
        }
        static MethodInfo OrderByMethodInfo;
        static MethodInfo OrderByDescendingMethodInfo;
        static MethodInfo ThenByMethodInfo;
        static MethodInfo ThenByDescendingMethodInfo;
    }
