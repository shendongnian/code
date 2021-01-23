    public sealed class GetFunctions
    {
        public static Func<object, int> GetFunction(MethodInfo methodInfo)
        {
            var obj = Expression.Parameter(typeof (object), "obj");
            var convert = Expression.Convert(obj, methodInfo.GetParameters().First().ParameterType);
            var call = Expression.Call(methodInfo, convert);
            var lambda = Expression.Lambda<Func<object, int>>(call, obj);
            return lambda.Compile();
        }
    }
    public class InvokeFunctions
    {
        public void invokeFunction()
        {
            MethodInfo methodInfo = typeof(Functions).GetMethod("SetStrValue");
            int i = GetFunctions.GetFunction(methodInfo).Invoke("hello");
            MethodInfo methodInfo2 = typeof(Functions).GetMethod("SetIntValue");
            int i2 = GetFunctions.GetFunction(methodInfo2).Invoke(1);
        }
    }
