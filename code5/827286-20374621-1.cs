    /// <summary>
    /// Creates UI element on a seperate thread and transfers it to
    /// main UI thread. 
    /// 
    /// Usage; if you have complex UI operation that takes a lot of time, such as XPS object creation.
    /// </summary>
    /// <param name="constructObject">Function that creates the necessary UIElement - will be executed on new thread</param>
    /// <param name="constructionCompleted">Callback to the function that receives the constructed object.</param>
    public void CreateElementOnSeperateThread(Func<UIElement> constructObject, Action<UIElement> constructionCompleted)
    {
        VerifyAccess();
    
        // save dispatchers for future usage.
        // we create new element on a seperate STA thread
        // and then basically swap UIELEMENT's Dispatcher.
        Dispatcher threadDispatcher = null;
        var currentDispatcher = Dispatcher.CurrentDispatcher;
    
        var ev = new AutoResetEvent(false);
        var thread = new Thread(() =>
            {
                threadDispatcher = Dispatcher.CurrentDispatcher;
                ev.Set();
    
                Dispatcher.Run();
            });
    
        thread.SetApartmentState(ApartmentState.STA);
        thread.IsBackground = true;
        thread.Start();
    ev.WaitOne();
    threadDispatcher.BeginInvoke(new Action(() =>
        {
            var constructedObject = constructObject();
            currentDispatcher.BeginInvoke(new Action(() =>
                {
                    var fieldinfo = typeof (DispatcherObject).GetField("_dispatcher",
                                                                       BindingFlags.NonPublic |
                                                                       BindingFlags.Instance);
                    if (fieldinfo != null)
                        fieldinfo.SetValue(constructedObject, currentDispatcher);
                    constructionCompleted(constructedObject);
                    threadDispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
                }), DispatcherPriority.Normal);
        }), DispatcherPriority.Normal);
}
