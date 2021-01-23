    public class Foo
    {
        #region Fields
        private readonly Dictionary<string, Tuple<Func<Foo, object>, Action<Foo, object>>> dataProperties = new Dictionary<string, Tuple<Func<Foo, object>, Action<Foo, object>>>();
        #endregion
        #region Properties
        public string Name { get; set; }
        public string Data1 { get; set; }
        public string Data2 { get; set; }
        public string Data3 { get; set; }
        public int ID { get; set; }
        #endregion
        #region Methods: public
        public void BuildDataProperties()
        {
            foreach (
                var keyValuePair in
                    GetType()
                        .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                        .Where(p => p.Name.StartsWith("Data"))
                        .Select(p => new KeyValuePair<string, Tuple<Func<Foo, object>, Action<Foo, object>>>(p.Name, Tuple.Create(GetGetter(this, p.Name), GetSetter(this, p.Name))))) {
                            dataProperties.Add(keyValuePair.Key, keyValuePair.Value);
                        }
        }
        #endregion
        #region Methods: private
        private Func<T, object> GetGetter<T>(T obj, string propertyName)
        {
            ParameterExpression arg = Expression.Parameter(obj.GetType(), "x");
            MemberExpression expression = Expression.Property(arg, propertyName);
            UnaryExpression conversion = Expression.Convert(expression, typeof(object));
            return Expression.Lambda<Func<T, object>>(conversion, arg).Compile();
        }
        private Action<T, object> GetSetter<T>(T obj, string propertyName)
        {
            ParameterExpression targetExpr = Expression.Parameter(obj.GetType(), "Target");
            MemberExpression propExpr = Expression.Property(targetExpr, propertyName);
            ParameterExpression valueExpr = Expression.Parameter(typeof(object), "value");
            MethodCallExpression convertExpr = Expression.Call(typeof(Convert), "ChangeType", null, valueExpr, Expression.Constant(propExpr.Type));
            UnaryExpression valueCast = Expression.Convert(convertExpr, propExpr.Type);
            BinaryExpression assignExpr = Expression.Assign(propExpr, valueCast);
            return Expression.Lambda<Action<T, object>>(assignExpr, targetExpr, valueExpr).Compile();
        }
        #endregion
    }
