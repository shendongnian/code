    public class BazMetaObject : DynamicMetaObject
    {
        public BazMetaObject(Expression expression, Baz value)
            : base(expression, BindingRestrictions.Empty, value)
        {
        }
        public override DynamicMetaObject BindInvokeMember(
            InvokeMemberBinder binder, DynamicMetaObject[] args)
        {
           if (binder.Name == "Foo")
           {
                return new DynamicMetaObject(
                    Expression.Call(
                        typeof(BazMetaObject).GetMethod("DynamicFoo")
                    ),
                    BindingRestrictions.Empty
                );
            }
            return base.BindInvokeMember(binder, args);
        }
        public static int DynamicFoo()
        {
            return 1234;
        }
    }
