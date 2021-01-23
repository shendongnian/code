    public abstract class SimpleInterceptor : IInterceptor
    {
        private bool proceedInvocation = true;
        /// <summary>
        /// Intercepts the specified invocation.
        /// </summary>
        /// <param name="invocation">The invocation to intercept.</param>
        public void Intercept( IInvocation invocation )
        {
            BeforeInvoke( invocation );
            if (proceedInvocation)
            {
                invocation.Proceed();
                AfterInvoke( invocation );
            }
        }
        /// <summary>
        /// When called in BeforeInvoke then the invokation in not proceeded anymore.
        /// Or in other words the decorated method and AfterInvoke won't be called anymore.
        /// Make sure you have assigned the return value in case it is not void.
        /// </summary>
        protected void DontProceedInvokation()
        {
            this.proceedInvocation = false;
        }
        /// <summary>
        /// Takes some action before the invocation proceeds.
        /// </summary>
        /// <param name="invocation">The invocation that is being intercepted.</param>
        protected virtual void BeforeInvoke( IInvocation invocation )
        {
        }
        /// <summary>
        /// Takes some action after the invocation proceeds.
        /// </summary>
        /// <param name="invocation">The invocation that is being intercepted.</param>
        protected virtual void AfterInvoke( IInvocation invocation )
        {
        }
    }
