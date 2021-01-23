    public static class CopyToExt
    {
        private static readonly ConcurrentDictionary<Type, LambdaExpression> expressions;
        private static readonly ConcurrentDictionary<Type, Object> funcs;
        private static readonly ConcurrentDictionary<Type, LambdaExpression> mergeStackExpr;
        private static ConcurrentDictionary<Type, Object> mergeStackFunc;
        public static MethodInfo AsQueryableMethod;
        public static MethodInfo SelectMethod;
        public static MethodInfo ToListMethod;
        public static MethodInfo CopyToMethod;
        public static MethodInfo AddMergeMethod;
        public static MethodInfo CreateMergeMethod;
        public static MethodInfo TryCopyMethod;
        static CopyToExt()
        {
            mergeStackExpr = new ConcurrentDictionary<Type, LambdaExpression>(new Dictionary<Type, LambdaExpression>());
            foreach (MethodInfo m in typeof(Queryable).GetMethods().Where(m => m.Name == "Select"))
                foreach (ParameterInfo p in m.GetParameters().Where(p => p.Name.Equals("selector")))
                    if (p.ParameterType.GetGenericArguments().Any(x => x.GetGenericArguments().Count() == 2))
                        SelectMethod = (MethodInfo)p.Member;
            foreach (MethodInfo m in typeof(Enumerable).GetMethods().Where(m => m.Name == "ToList"))
                foreach (ParameterInfo p in m.GetParameters().Where(p => p.Name.Equals("source")))
                    if (p.ParameterType.GetGenericArguments().Count() == 1)
                        ToListMethod = (MethodInfo)p.Member;
            foreach (MethodInfo m in typeof(Queryable).GetMethods().Where(m => m.Name == "AsQueryable"))
                foreach (ParameterInfo p in m.GetParameters().Where(p => p.Name.Equals("source")))
                    if (p.ParameterType.GetGenericArguments().Count() == 1)
                        AsQueryableMethod = (MethodInfo)p.Member;
            CreateMergeMethod = typeof(CopyToExt).GetMethods().First(m => m.Name == "CreateMergeStack");
            AddMergeMethod = typeof(MergeStack).GetMethods().First(m => m.Name == "AddReturnOrCreateAddReturn");
            TryCopyMethod = typeof(MergeStack).GetMethods().First(m => m.Name == "TryCopy");
        }
        public static IQueryable<TDest> CopyTo<TSrc, TDest>(this IQueryable<TSrc> queryable)
            where TSrc : class, IEntity
            where TDest : class, IEntity
        {
            var copyExpr = CreateTryCopy<TSrc, TDest>();
            var ms = CreateMergeStack<TSrc>();
            return queryable.Select(ms).Select(copyExpr);
        }
        public static IEnumerable<TDest> CopyTo<TSrc, TDest>(this IEnumerable<TSrc> queryable)
            where TSrc : class, IEntity
            where TDest : class, IEntity
        {
            return queryable.AsQueryable().CopyTo<TSrc, TDest>().AsEnumerable();
        }
        public static Expression<Func<TSrc, Stackholder<TSrc>>> CreateMergeStack<TSrc>()
        {
            return mergeStackExpr.GetOrAdd(typeof(TSrc), (type) =>
            {
                var shtype = typeof(Stackholder<TSrc>);
                var parm = Expression.Parameter(typeof(TSrc));
                var destNewExpr = Expression.New(shtype);
                var methodcall = Expression.Call(null,
                    CopyToExt.AddMergeMethod);
                var memInit = Expression.MemberInit(destNewExpr,
                    Expression.Bind(shtype.GetField("Src"), parm),
                    Expression.Bind(shtype.GetField("Ms"), methodcall));
                return Expression.Lambda<Func<TSrc, Stackholder<TSrc>>>(memInit, parm);
            }) as Expression<Func<TSrc, Stackholder<TSrc>>>;
        }
        public static Expression<Func<Stackholder<TSrc>, TDest>> CreateTryCopy<TSrc, TDest>()
        {
            var shtype = typeof(Stackholder<TSrc>);
            var parentParam = Expression.Parameter(shtype);
            var SrcExpr = Expression.PropertyOrField(parentParam, "Src");
            var MSExpr = Expression.PropertyOrField(parentParam, "Ms");
            var tcMethod = Expression.Call(MSExpr,
                TryCopyMethod.MakeGenericMethod(new Type[] { typeof(TSrc), typeof(TDest) }),
                SrcExpr);
            return Expression.Lambda<Func<Stackholder<TSrc>, TDest>>(tcMethod, parentParam);
        }
        internal static bool Impliments(this Type type, Type inheritedType)
        {
            return (type.IsSubclassOf(inheritedType) || type.GetInterface(inheritedType.FullName) != null);
        }
        internal static bool Impliments<T>(this Type type, Type inheritedType = null)
        {
            return type.Impliments(typeof(T));
        }
        private static ConcurrentDictionary<Type, Object> AssignDict =
            new ConcurrentDictionary<Type, Object>(new Dictionary<Type, Object>());
        internal static Func<TSrc, TDest, MergeStack, TDest> Assign<TSrc, TDest>()
        {
            return (Func<TSrc, TDest, MergeStack, TDest>) AssignDict.GetOrAdd(typeof (Func<TSrc, TDest>), (indexType) =>
            {
                var tSrc = typeof (TSrc);
                var tDest = typeof (TDest);
                var srcEntityInterfaces = tSrc.GetInterfaces().Where(x => x.Impliments<IEntity>());
                var destEntityInterfaces = tDest.GetInterfaces().Where(x => x.Impliments<IEntity>());
                var srcParam = Expression.Parameter(tSrc);
                var destParam = Expression.Parameter(tDest);
                var MSExpr = Expression.Parameter(typeof (MergeStack));
                var common = destEntityInterfaces.Intersect(srcEntityInterfaces);
                var memberbindings = common.Where(x => x.Impliments<IEntityProperty>())
                    .Select(type => type.GetProperties().First())
                    .Select(
                        prop =>
                            Expression.Assign(Expression.Property(destParam, prop.Name),
                                Expression.Property(srcParam, prop.Name)))
                    .Cast<Expression>().ToList();
                foreach (var type in common.Where(x => x.Impliments<IEntityObject>()))
                {
                    var destSubType = destEntityInterfaces.First(x => x.Impliments(type))
                        .GetGenericArguments()
                        .First();
                    var srcSubType = srcEntityInterfaces.First(x => x.Impliments(type))
                        .GetGenericArguments()
                        .First();
                    var dProp = destEntityInterfaces.First(x => x.Impliments(type)).GetProperties().First();
                    var sProp = srcEntityInterfaces.First(x => x.Impliments(type)).GetProperties().First();
                    var tcParam = Expression.Parameter(srcSubType);
                    var tcMethod = Expression.Call(MSExpr,
                        TryCopyMethod.MakeGenericMethod(new Type[] {srcSubType, destSubType}),
                        tcParam);
                    LambdaExpression mergeLambda = Expression.Lambda(tcMethod, tcParam);
                    MemberExpression memberExpression = Expression.Property(srcParam, sProp.Name);
                    InvocationExpression invocationExpression = Expression.Invoke(mergeLambda,
                        Expression.Property(srcParam, sProp.Name));
                    var check = Expression.Condition(
                        Expression.MakeBinary(ExpressionType.NotEqual, memberExpression,
                            Expression.Constant(null, sProp.PropertyType)), invocationExpression,
                        Expression.Constant(null, invocationExpression.Type));
                    BinaryExpression binaryExpression = Expression.Assign(Expression.Property(destParam, dProp.Name),
                        check);
                    memberbindings.Add(binaryExpression);
                }
                foreach (var type in common.Where(x => x.Impliments<IEntityCollection>()))
                {
                    var destSubType = destEntityInterfaces.First(x => x.Impliments(type))
                        .GetGenericArguments()
                        .First();
                    var srcSubType = srcEntityInterfaces.First(x => x.Impliments(type))
                        .GetGenericArguments()
                        .First();
                    var dProp = destEntityInterfaces.First(x => x.Impliments(type)).GetProperties().First();
                    var sProp = srcEntityInterfaces.First(x => x.Impliments(type)).GetProperties().First();
                    var tcParam = Expression.Parameter(srcSubType);
                    var tcMethod = Expression.Call(MSExpr,
                        TryCopyMethod.MakeGenericMethod(new Type[] {srcSubType, destSubType}),
                        tcParam);
                    LambdaExpression mergeLambda = Expression.Lambda(tcMethod, tcParam);
                    var memberExpression = Expression.Property(srcParam, sProp.Name);
                    var selectExpr = Expression.Call(null,
                        AsQueryableMethod.MakeGenericMethod(new Type[] {srcSubType}),
                        new Expression[] {memberExpression});
                    selectExpr = Expression.Call(null,
                        CopyToExt.SelectMethod.MakeGenericMethod(new Type[] {srcSubType, destSubType}),
                        new Expression[] {selectExpr, mergeLambda});
                    selectExpr = Expression.Call(null,
                        CopyToExt.ToListMethod.MakeGenericMethod(new Type[] {destSubType}),
                        new Expression[] {selectExpr});
                    var check = Expression.Condition(
                        Expression.MakeBinary(ExpressionType.NotEqual, memberExpression,
                            Expression.Constant(null, sProp.PropertyType)), selectExpr,
                        Expression.Constant(null, selectExpr.Type));
                    memberbindings.Add(Expression.Assign(Expression.Property(destParam, dProp.Name), check));
                }
                memberbindings.Add(destParam);
                return
                    Expression.Lambda<Func<TSrc, TDest, MergeStack, TDest>>(Expression.Block(memberbindings),
                        new ParameterExpression[] {srcParam, destParam, MSExpr}).Compile();
            });
        }
    }
    public class Stackholder<TSrc>
    {
        public MergeStack Ms;
        public TSrc Src;
    }
    public class MergeStack
    {
        private static ConcurrentDictionary<Thread, MergeStack> StackDict = new ConcurrentDictionary<Thread, MergeStack>(new Dictionary<Thread, MergeStack>());
        private readonly Dictionary<Type, Dictionary<Object, Object>> _mergeObjDict = new Dictionary<Type, Dictionary<object, object>>();
        public static MergeStack AddReturnOrCreateAddReturn()
        {
            return StackDict.GetOrAdd(Thread.CurrentThread, (x) => new MergeStack() { });
        }
        public TDest TryCopy<TSrc, TDest>(TSrc Src)
            where TSrc : class, IEntity
            where TDest : class, IEntity, new()
        {
            if (Src == null) return null;
            var objToIndex = new TDest();
            Dictionary<object, object> objToObj;
            if (!_mergeObjDict.ContainsKey(objToIndex.GetType()))
            {
                objToObj = new Dictionary<object, object>();
                _mergeObjDict.Add(objToIndex.GetType(), objToObj);
            }
            else
            {
                objToObj = _mergeObjDict[objToIndex.GetType()];
            }
            if (!objToObj.ContainsKey(Src))
            {
                objToObj.Add(Src, objToIndex);
                return CopyToExt.Assign<TSrc, TDest>()(Src, objToIndex, this);
            }
            return objToObj[Src] as TDest;
        }
    }
