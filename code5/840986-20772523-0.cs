    public class DataEntry : Dictionary<string, object>
    {
        public DataEntry(IDictionary<string, object> entry)
            : base(entry)
        {
        }
        private object GetEntryValue(string propertyName)
        {
            return base[propertyName];
        }
    }
    public class DynamicDataEntry : DataEntry, IDynamicMetaObjectProvider
    {
        internal DynamicDataEntry()
            : base(new Dictionary<string, object>())
        {
        }
        public DynamicDataEntry(IDictionary<string, object> entry)
            : base(entry)
        {
        }
        public DynamicMetaObject GetMetaObject(Expression parameter)
        {
            return new DynamicEntryMetaObject(parameter, this);
        }
        private class DynamicEntryMetaObject : DynamicMetaObject
        {
            internal DynamicEntryMetaObject(
                Expression parameter,
                DynamicDataEntry value)
                : base(parameter, BindingRestrictions.Empty, value)
            {
            }
            public override DynamicMetaObject BindGetMember(GetMemberBinder binder)
            {
                var methodInfo = typeof(DataEntry).GetMethod("GetEntryValue", BindingFlags.Instance | BindingFlags.NonPublic);
                var arguments = new Expression[]
            {
                Expression.Constant(binder.Name)
            };
                Expression objectExpression = Expression.Call(
                    Expression.Convert(Expression, LimitType), 
                    methodInfo, arguments);
                return new DynamicMetaObject(
                    objectExpression,
                    BindingRestrictions.GetTypeRestriction(Expression, this.RuntimeType));
            }
        }
    }
