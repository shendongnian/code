    public class JobContext<T> : IDisposable
    {
        public ILifetimeScope Scope { get; set; }
        public void Execute(string methodName, params object[] args)
        {
            var instance = Scope.Resolve<T>();
            var methodInfo = typeof(T).GetMethod(methodName);
            ConvertParameters(methodInfo, args);
            methodInfo.Invoke(instance, args);
        }
        private void ConvertParameters(MethodInfo targetMethod, object[] args)
        {
            var methodParams = targetMethod.GetParameters();
            for (int i = 0; i < methodParams.Length && i < args.Length; i++)
            {
                if (args[i] == null) continue;
                if (!methodParams[i].ParameterType.IsInstanceOfType(args[i]))
                {
                    // try convert 
                    args[i] = args[i].ConvertType(methodParams[i].ParameterType);
                }
            }
        }
        
        void IDisposable.Dispose()
        {
            if (Scope != null)
                Scope.Dispose();
            Scope = null;
        }
    }
