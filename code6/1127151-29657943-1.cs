    public static void AddEventHandler(this EventInfo eventInfo, object client, EventHandler handler)
    {
            object eventInfoHandler = eventInfo.EventHandlerType
                .GetConstructor(new[] { typeof(object), typeof(IntPtr) })
                .Invoke(new[] { handler.Target, handler.Method.MethodHandle.GetFunctionPointer() });
            eventInfo.AddEventHandler(client, (Delegate)eventInfoHandler);
    }
