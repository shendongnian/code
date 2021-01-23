    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class LoggingAttribute : Attribute
    {
    }
    public interface IClassNotToBeIntercepted
    {
        void DoSomething();
    }
    public class ClassNotToBeIntercepted : IClassNotToBeIntercepted
    {
        public void DoSomething() { }
    }
    public interface IClassToBeIntercepted
    {
        void DoNotLogThis();
        void LogThis();
        void LogThisAsWell();
    }
    public class ClassToBeIntercepted : IClassToBeIntercepted
    {
        public void DoNotLogThis() { }
        [Logging]
        public void LogThis() { }
        [Logging]
        public void LogThisAsWell() { }
    }
    public class LoggingInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("interceptor before {0}", BuildLogName(invocation));
            
            invocation.Proceed();
            Console.WriteLine("interceptor after {0}", BuildLogName(invocation));
        }
        private static string BuildLogName(IInvocation invocation)
        {
            return string.Format(
                "{0}.{1}", 
                invocation.Request.Target.GetType().Name,
                invocation.Request.Method.Name);
        }
    }
    public class DemoModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind(convention => convention
                .FromThisAssembly()
                .SelectAllClasses()
                .Where(ContainsMethodWithLoggingAttribute)
                .BindDefaultInterface()
                .Configure(x => x
                    .Intercept()
                    .With<LoggingInterceptor>()));
            this.Bind<IClassNotToBeIntercepted>()
                .To<ClassNotToBeIntercepted>();
        }
        private static bool ContainsMethodWithLoggingAttribute(Type type)
        {
            return type
                .GetMethods()
                .Any(method => method.HasAttribute<LoggingAttribute>());
        }
    }
