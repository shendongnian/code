    // Provides a means of invoking an assembly in an isolated appdomain
    public static class IsolatedInvoker
    {
        // main Invoke method
        public static void Invoke(string exePath, string typeName, string methodName, object[] parameters)
        {
            // resolve path
            var exeFullPath = Path.Combine(Environment.CurrentDirectory, exePath);
            Debug.Assert(exeFullPath != null);
            // get base path
            var appBasePath = Path.GetDirectoryName(exeFullPath);
            Debug.Assert(appBasePath != null);
            // change current directory
            var oldDirectory = Environment.CurrentDirectory;
            Environment.CurrentDirectory = appBasePath;
            try
            {
                // create new app domain
                var domain = AppDomain.CreateDomain("testDomain", null, appBasePath, null, false);
                try
                {
                    // create invoker helper instance
                    var invoker = (InvokerHelper) domain.CreateInstanceFromAndUnwrap(Assembly.GetExecutingAssembly().Location, typeof(InvokerHelper).FullName);
                    // invoke method
                    var result = invoker.InvokeHelper(exePath, typeName, methodName, parameters);
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
        public class InvokerHelper : MarshalByRefObject
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
