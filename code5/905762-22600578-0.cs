    public void SomeMethod(string p1, int p2, object p3)
    {
        Dictionary<string, string> dic = ExtractParametersAndMakeItAsDictionary(p1, p2, p3);
    }
    
    private Dictionary<string, string> ExtractParametersAndMakeItAsDictionary(params object[] parameters)
    {
        StackTrace stackTrace = new StackTrace();
        string methodName = stackTrace.GetFrame(1).GetMethod().Name;
        ParameterInfo[] parameterInfos = GetType().GetMethod(methodName).GetParameters();
    
        return parameters.Where(p => p != null).Zip(parameterInfos, (pv, pi) => new { Name = pi.Name, Value = pv.ToString() }).ToDictionary(x => x.Name, x => x.Value);
    }
