    public class MyClass
    {
        public void MyMethod(string s)
        {
        }
    }
    public object Execute(object obj, string methodName, object[] arguments)
    {
        Type type = obj.GetType();
        MethodInfo methodInfo = type.GetMethod(methodName);
        return methodInfo.Invoke(obj, arguments);
    }
