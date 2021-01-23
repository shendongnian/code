        private class AsyncExceptionHandlingInterceptor : IInterceptor
        {
            private static readonly MethodInfo handleAsyncMethodInfo = typeof(AsyncExceptionHandlingInterceptor).GetMethod("HandleAsyncWithResult", BindingFlags.Instance | BindingFlags.NonPublic);
            private readonly IExceptionHandler _handler;
            public AsyncExceptionHandlingInterceptor(IExceptionHandler handler)
            {
                _handler = handler;
            }
            public void Intercept(IInvocation invocation)
            {
                var delegateType = GetDelegateType(invocation);
                if (delegateType == MethodType.Synchronous)
                {
                    _handler.HandleExceptions(() => invocation.Proceed());
                }
                if (delegateType == MethodType.AsyncAction)
                {
                    invocation.Proceed();
                    invocation.ReturnValue = HandleAsync((Task)invocation.ReturnValue);
                }
                if (delegateType == MethodType.AsyncFunction)
                {
                    invocation.Proceed();
                    ExecuteHandleAsyncWithResultUsingReflection(invocation);
                }
            }
            private void ExecuteHandleAsyncWithResultUsingReflection(IInvocation invocation)
            {
                var resultType = invocation.Method.ReturnType.GetGenericArguments()[0];
                var mi = handleAsyncMethodInfo.MakeGenericMethod(resultType);
                invocation.ReturnValue = mi.Invoke(this, new[] { invocation.ReturnValue });
            }
            private async Task HandleAsync(Task task)
            {
                await _handler.HandleExceptions(async () => await task);
            }
        
            private async Task<T> HandleAsyncWithResult<T>(Task<T> task)
            {
                return await _handler.HandleExceptions(async () => await task);
            }
            private MethodType GetDelegateType(IInvocation invocation)
            {
                var returnType = invocation.Method.ReturnType;
                if (returnType == typeof(Task))
                    return MethodType.AsyncAction;
                if (returnType.IsGenericType && returnType.GetGenericTypeDefinition() == typeof(Task<>))
                    return MethodType.AsyncFunction;
                return MethodType.Synchronous;
            }
            private enum MethodType
            {
                Synchronous,
                AsyncAction,
                AsyncFunction
            }
        }
