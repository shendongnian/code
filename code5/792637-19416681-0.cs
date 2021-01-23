    [AttributeUsage(AttributeTargets.Class)]
    public class ValidationAttribute : HandlerAttribute
    {
        public ValidationAttribute(int order = 1)
        {
            Order = order;
        }
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            var handler = container.Resolve<ValidationHandler>();
            handler.Order = Order;
            return handler;
        }
    }
    public class TransactionAttribute : HandlerAttribute
    {
        public TransactionAttribute(int order = 2)
        {
            Order = order;
        }
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            var handler = container.Resolve<TransactionHandler>();
            handler.Order = Order;
            return handler;
        }
    }
    public class NotifyAttribute : HandlerAttribute
    {
        public NotifyAttribute(int order = 3)
        {
            Order = order;
        }
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            var handler = container.Resolve<NotifyHandler>();
            handler.Order = Order;
            return handler;
        }
    }
    public class ValidationHandler : ICallHandler
    {
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            Console.WriteLine("Validation!");
            return getNext().Invoke(input, getNext);
        }
        public int Order
        {
            get;
            set;
        }
    }
    public class TransactionHandler : ICallHandler
    {
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            Console.WriteLine("Transaction!");
            return getNext().Invoke(input, getNext);
        }
        public int Order
        {
            get;
            set;
        }
    }
    public class NotifyHandler : ICallHandler
    {
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            Console.WriteLine("Notify!");
            return getNext().Invoke(input, getNext);
        }
        public int Order
        {
            get;
            set;
        }
    }
    [Validation]
    public class TestClass
    {
        public virtual int TestProperty
        {
            get;
            [Transaction]
            [Notify]
            set;
        }
    }
