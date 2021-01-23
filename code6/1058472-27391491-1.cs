    protected virtual void OnLogUpdate(string logMessage)
    {
        if (logMessage == "")
            return;
        MessageEventArgs e = new MessageEventArgs();
        var handler = LogMessage;
        if (handler != null)
        {
            e.msgContent = logMessage;
            handler(this, e);
        }
    }
 
