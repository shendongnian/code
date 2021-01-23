    public class MyServiceWrapper
    {
        Type _serviceType;
        public MyServiceWrapper(Type serviceType)
        {
            _serviceType = serviceType;
        }
    
        public object CreateInstance()
        {
            ... code from above ...
        }
    
        public YourObject InvokeServiceMethod() 
        {
            var instance = CreateInstance();
            var methodInfo = _serviceType.GetMethod("MethodName");
            return (YourObject) methodInfo.Invoke(instance, anyArguments);
        }
    }
