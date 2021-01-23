    // your global handler, it can be regular method
    private static void GlobalEventHandler(object o, AsyncCompletedEventArgs e)
    {
        Console.WriteLine(e.GetType());
    }
    // your extension method
    public static void AssignDelegate(this object client, string eventName)
    {
        // get event
        EventInfo eventInfo = client.GetType().GetEvent(eventName);
        // get build handler method
        MethodInfo buildHandlerMethod = MethodInfo.GetCurrentMethod().DeclaringType.GetMethod("BuildHandler");
        // get type of arg; 
        // eventInfo.EventHandlerType is EventHandler<T>, where T: AsyncCompletedEventArgs, 
        // so we are interested in T
        Type argType = eventInfo.EventHandlerType.GetGenericArguments()[0];
        // add handler
        eventInfo.AddEventHandler(client, (Delegate)buildHandlerMethod.MakeGenericMethod(argType).Invoke(null, null));
    }
    // method which returns proper handler for event, 
    // it delegates invocation to GlobalEventHandler
    public static EventHandler<T> BuildHandler<T>() where T : AsyncCompletedEventArgs
    {
        return GlobalEventHandler;
    }
