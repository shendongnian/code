      [Serializable]
      public class LoggingAspect : MethodInterceptionAspect
      {
        IMyLogger _log;
 
        public override void RuntimeInitialize(MethodBase method)
        {
            _log = MyServiceLocator.Get();
        }
 
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            var methodName = args.Method.Name;
            var parameters = args.Method.GetParameters();
 
            _log.WriteLine(string.Format("{0} timestamp: {1}", methodName, 
                    DateTime.Now));
 
            for (var i = 0; i &lt; args.Arguments.Count; i++)
                _log.WriteLine(string.Format("{0} argument #{1}, {2} ({3}): {4}",
                    methodName,
                    i,
                    parameters[i].Name,
                    parameters[i].ParameterType,
                    args.Arguments[i]));
 
            args.Proceed();
 
            _log.WriteLine(string.Format("{0} return value: {1}", methodName, 
                args.ReturnValue));
        }
    }
