    private GenerateWrappedDelegate(EventInfo eventInfo)
    {
      var eventHandlerType = eventInfo.EventHandlerType;
      var parameters = eventHandlerType.GetMethod("Invoke").GetParameters();
      var methodName = string.Format("Arity{0}", parameters.Length);
      var eventRegisterMethod = typeof(EventMonitor)
            .GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance)
            .MakeGenericMethod(parameters.Select(p => ParameterType).ToArray());
      return Delegate.CreateDelegate(eventHandlerType, this, eventRegisterMethod);
    }
    private void Arity1<T>(T arg1)
    {
      Handle(() => handler.DynamicInvoke(arg1));
    }
    private void Arity2<T1, T2>(T1 arg1, T2 arg2)
    {
      Handle(() => handler.DynamicInvoke(arg1, arg2));
    }
