    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new DynamicProxy(new Calculator(), typeof(ICalculator)).GetTransparentProxy().GetType());
        }
    }
    public interface ICalculator
    {
        double Add(double x, double y);
    }
    class Calculator : ICalculator
    {
        public double Add(double x, double y)
        {
            throw new NotImplementedException();
        }
    }
    class DynamicProxy : RealProxy
    {
        private readonly object _decorated;
        private readonly Type _reportedType;
        private static readonly MethodInfo GetTypeMethodInfo = typeof(object).GetMethod("GetType");
        public DynamicProxy(object decorated, Type reportedType)
            : base(reportedType)
        {
            _decorated = decorated;
            _reportedType = reportedType;
        }
        private void Log(string msg, object arg = null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg, arg);
            Console.ResetColor();
        }
        public override IMessage Invoke(IMessage msg)
        {
            var methodCall = msg as IMethodCallMessage;
            var methodInfo = methodCall.MethodBase as MethodInfo;
            Log("In Dynamic Proxy - Before executing '{0}'",
              methodCall.MethodName);
            try
            {
                object result;
                if (GetTypeMethodInfo.Equals(methodInfo))
                {
                    result = _reportedType;
                }
                else
                {
                    result = methodInfo.Invoke(_decorated, methodCall.InArgs);
                }
                
                Log("In Dynamic Proxy - After executing '{0}' ",
                  methodCall.MethodName);
                return new ReturnMessage(result, null, 0,
                  methodCall.LogicalCallContext, methodCall);
            }
            catch (Exception e)
            {
                Log(string.Format(
                  "In Dynamic Proxy- Exception {0} executing '{1}'", e),
                  methodCall.MethodName);
                return new ReturnMessage(e, methodCall);
            }
        }
    }
