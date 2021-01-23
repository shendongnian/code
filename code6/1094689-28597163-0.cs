        [Serializable]
        public class Pet
        {
            public virtual String Name { get; set; }
            public virtual IDictionary<String, Int32> Dict { get; set; }
            public Pet()
            {
                this.Dict = Something.MakeSomething<IDictionary<String, Int32>>(new Dictionary<String, Int32>());
            }
            public override String ToString()
            {
                return String.Format("Name: {0}, Age: {1}", Name, Dict);
            }
        }
        public static class Something
        {
            private static readonly ProxyGenerator _generator = new ProxyGenerator(new PersistentProxyBuilder());
            public static TSomething MakeSomething<TSomething>() where TSomething : class, new()
            {
                TSomething proxy = _generator.CreateClassProxy<TSomething>(new MyInterceptor());
                return proxy;
            }
            public static TSomething MakeSomething<TSomething>(TSomething instance) where TSomething : class
            {
                TSomething proxy = _generator.CreateInterfaceProxyWithTargetInterface<TSomething>(instance, new MyInterceptor());
                return proxy;
            }
        }
        [Serializable]
        public class MyInterceptor : IInterceptor
        {
            public void Intercept(IInvocation invocation)
            {
                invocation.Proceed();
                if (invocation.Method.IsSpecialName && invocation.Method.Name.StartsWith("set_"))
                {
                    PropertyInfo pi = invocation.TargetType.GetProperty(invocation.Method.Name.Substring(4), BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
                    Console.WriteLine("{0}[{1}]({2})", pi.Name, pi.PropertyType, String.Join(" - ", invocation.Arguments.Select(a => a.ToString()).ToArray()));
                }
            }
        }
