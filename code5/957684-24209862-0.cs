    ComponentDispatcher.ThreadFilterMessage += new ThreadMessageEventHandler(OnThreadMessage);
    
    static void OnThreadMessage(ref MSG msg, ref bool handled)
    {
        if (!handled)
        {
            if (msg.message == WmHotKey)
            {
                // intercept alt+print screen here, do custom action
            }
        }
    }
