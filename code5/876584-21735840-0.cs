    public class DBEntity
    {
        public short Prop1 { get; protected set; }
        public string Prop2 { get; protected set; }
        public DBEntity()
        {
        }
        public void Update<T>( Expression<Func<DBEntity, T>> outExpr, T value)
        {
            if (value != null)
            {
                var expr = (MemberExpression)outExpr.Body;
                var prop = (PropertyInfo)expr.Member;
                prop.SetValue(this, value, null);
            }
        }
    }
