    // Provides a means of invoking an assembly in an isolated appdomain
    public static class IsolatedInvoker
    {
        // main Invoke method
        public static void Invoke(string assemblyFile, string typeName, string methodName, object[] parameters)
        {
            // resolve path
            assemblyFile = Path.Combine(Environment.CurrentDirectory, assemblyFile);
            Debug.Assert(assemblyFile != null);
            // get base path
            var appBasePath = Path.GetDirectoryName(assemblyFile);
            Debug.Assert(appBasePath != null);
            // change current directory
            var oldDirectory = Environment.CurrentDirectory;
            Environment.CurrentDirectory = appBasePath;
            try
            {
                // create new app domain
                var domain = AppDomain.CreateDomain(Guid.NewGuid().ToString(), null, appBasePath, null, false);
                try
                {
                    // create instance
                    var invoker = (InvokerHelper) domain.CreateInstanceFromAndUnwrap(Assembly.GetExecutingAssembly().Location, typeof(InvokerHelper).FullName);
                    // invoke method
                    var result = invoker.InvokeHelper(assemblyFile, typeName, methodName, parameters);
                    // process result
                    Debug.WriteLine(result);
                }
                finally
                {
                    // unload app domain
                    AppDomain.Unload(domain);
                }
            }
            finally
            {
                // revert current directory
                Environment.CurrentDirectory = oldDirectory;
            }
        }
        // This helper class is instantiated in an isolated app domain
        private class InvokerHelper : MarshalByRefObject
        {
            // This helper function is executed in an isolated app domain
            public object InvokeHelper(string assemblyFile, string typeName, string methodName, object[] parameters)
            {
                // create an instance of the target object
                var handle = Activator.CreateInstanceFrom(assemblyFile, typeName);
                // get the instance of the target object
                var instance = handle.Unwrap();
                // get the type of the target object
                var type = instance.GetType();
                // invoke the method
                var result = type.InvokeMember(methodName, BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Instance, null, instance, parameters);
                // success
                return result;
            }
        }
    }
