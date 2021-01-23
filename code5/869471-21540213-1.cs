    private static Dictionary<string, Action<myObject>> _actions = new Dictionary<string, Action>() {
        { "SubProcess1", (x) => x.SubProcess1() },
        { "SubProcess2", (x) => x.SubProcess2() },
        { "SubProcess3", (x) => x.SubProcess3() },
    
    }
    
    public static void Process(this myObject,IList<string> MethodsToCallNames)
    {
        for(int i =0;i<MethodsToCallNames.Count;i++)
        {
            _actions[MethodsToCallNames[i]](myObject);
        }
    }
