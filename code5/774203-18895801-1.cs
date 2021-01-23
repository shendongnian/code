    public void MyFunction(object instance, List<string> methodlist)
    {
        foreach (string methodName in methodlist)
        {
            instance.GetType().GetMethod(methodName).Invoke(instance, null);
        }
