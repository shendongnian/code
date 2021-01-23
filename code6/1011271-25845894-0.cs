    private static void Main()
    {
        var eventHandler = new EventHandler();
        RegisterCallBackForSomeEventMethod(eventHandler.SomeMethodToUseAsACallBack);
    }
    private static void RegisterCallBackForSomeEventMethod(Action action)
    {
        Console.WriteLine(action.Target.GetType());
    }
