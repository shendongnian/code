    public class SomeProxyClass<I,O>
    {
        public Func<I, Nullable<O>> ActionName;
        public Nullable<O> InvokeActionName(I value)
        {
            if(this.ActionName != null)
            {
                return this.ActionName(value);
            }
            return null;
        }
    }
    public class SomeClass
    {
        public static SomeProxyClass<string, int> parentProxy = new SomeProxyClass<string, int>();
        public static int? ActionName(string value)
        {
            this.parentProxy.InvokeActionName(value);
        }
    }
