    /// <summary>
    /// A class that is capable to wrap arbitrary objects and "override" method GetHashCode()
    /// This is suitable for object that need to be passed to any WPF UI classes using them in
    /// a hashed list, set of other collection using hash codes.
    /// </summary>
    public class CustomProxyFactory
    {
        /// <summary>
        /// Interceptor class that stores a static hash code, "overrides" the
        /// method GetHashCode() and returns this static hash code instead of the real one
        /// </summary>
        public class HashCodeInterceptor : IInterceptor
        {
            private readonly int frozenHashCode;
            public HashCodeInterceptor( int frozenHashCode )
            {
                this.frozenHashCode = frozenHashCode;
            }
            public void Intercept( IInvocation invocation )
            {
                if (invocation.Method.Name.Equals( "GetHashCode" ) == true)
                {
                    invocation.ReturnValue = this.frozenHashCode;
                }
                else
                {
                    invocation.Proceed();
                }
            }
        }
        /// <summary>
        /// Factory method
        /// </summary>
        /// <param name="instance">Instance to be wrapped by a proxy</param>
        /// <returns></returns>
        public static T Create<T>( T instance ) where T : class
        {
            try
            {
                IInterceptor hashCodeInterceptor = new HashCodeInterceptor( instance.GetHashCode() );
                IInterceptor[] interceptors = new IInterceptor[] {hashCodeInterceptor};
                ProxyGenerator proxyGenerator = new ProxyGenerator();
                T proxy = proxyGenerator.CreateClassProxyWithTarget( instance, interceptors );
                return proxy;
            }
            catch (Exception ex)
            {
                Console.WriteLine( typeof(CustomProxyFactory).Name + ": Exception during proxy generation: " + ex );
                return default(T);
            }
        }
    }
