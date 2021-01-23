    public class Baz : Bar, IDynamicMetaObjectProvider
    {
        public DynamicMetaObject GetMetaObject(Expression parameter)
        {
            return new BazMetaObject(parameter, this);
        }
    }
