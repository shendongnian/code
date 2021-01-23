    public class Foo
    {
        // Fields.
        protected readonly List<Task> InitialisationTasks = new List<Task>();
        // Properties.
        // These have to be declared virtual
        // in order for dynamic proxying to work.
        public virtual string Bar { get; set; }
        protected Foo()
        {
            // Enforce proxy integrity.
            this.Validate();
            // Initialisation work.
            this.InitialisationTasks.Add(Task.Delay(500));
        }
        private void Validate()
        {
            var type = ProxyUtil.GetUnproxiedType(this);
            // No public constructors.
            if (type.GetConstructors().Length != 0)
            {
                throw new InvalidOperationException(
                    "Public constructors not supported in derived types."
                );
            }
            // No non-virtual properties.
            foreach (var property in type.GetProperties())
            {
                // We're only interested in getters.
                var method = property.GetGetMethod();
                if (method != null && !method.IsVirtual)
                {
                    throw new InvalidOperationException(
                        "Only virtual properties are supported."
                    );
                }
            }
        }
        // Responsible for instantiating dynamic
        // proxies of Foo and its derivatives.
        public static class Factory
        {
            // Static fields.
            static readonly ProxyGenerator ProxyGenerator = new ProxyGenerator();
            static readonly WaitForInitInterceptor Interceptor = new WaitForInitInterceptor();
            // Factory method.
            public static T Create<T>() where T : Foo
            {
                return ProxyGenerator.CreateClassProxy<T>(Interceptor);
            }
            class WaitForInitInterceptor : IInterceptor
            {
                public void Intercept(IInvocation invocation)
                {
                    // Applies to getters only.
                    if (invocation.Method.Name.StartsWith("get_"))
                    {
                        var foo = invocation.InvocationTarget as Foo;
                        if (foo != null)
                        {
                            // Block until initialisation completes.
                            Task.WhenAll(foo.InitialisationTasks).Wait();
                        }
                        // Continue to the target method.
                        invocation.Proceed();
                    }
                }
            }
        }
    }
