    static void Main() {
        var obj = new MyFunnyType(); // wow! null!
    }
    class MyFunnyProxyAttribute : ProxyAttribute {
        public override MarshalByRefObject CreateInstance(Type serverType) {
            return null;
        }
    }
    [MyFunnyProxy]
    class MyFunnyType : ContextBoundObject { }
