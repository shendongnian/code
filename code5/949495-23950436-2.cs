    public class ValueHolder
    {
        public static ValueHolder<T> Create<T>(Expression<Func<T>> staticProp, T tempVal)
        {
            var ex = (MemberExpression)staticProp.Body;
            var prop = (PropertyInfo)ex.Member;
            var getter = (Func<T>)Delegate.CreateDelegate(typeof(Func<T>), prop.GetGetMethod());
            var setter = (Action<T>)Delegate.CreateDelegate(typeof(Action<T>), prop.GetSetMethod());
            return new ValueHolder<T>(getter, tempVal, setter);
        }
    }
