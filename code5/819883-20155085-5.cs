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
                    Expression.Convert(
                        Expression.Call(
                            typeof (BazMetaObject).GetMethod("DynamicFoo")
                        ),
                        typeof (object)
                    ),
                    BindingRestrictions.GetTypeRestriction(
                        this.Expression,
                        this.LimitType
                    )
                );
            }
            return base.BindInvokeMember(binder, args);
        }
        public static int DynamicFoo()
        {
            return 1234;
        }
    }
