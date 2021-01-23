    IMethodReturn ICallHandler.Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
    {
        IMethodReturn result = input.CreateMethodReturn(null, new object[0]);
        var fieldInfos = input.Target.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
        var businessField = fieldInfos.FirstOrDefault(f => f.Name == "_business");
        if (businessField != null && businessField.GetValue(input.Target) != null)
            result = getNext()(input, getNext);
        return result;
    }
