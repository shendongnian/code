    public static event MessageEventHandler MessageEvent;
            public delegate void MessageEventHandler(object sender, ServiceEventArgs e);
    
            IClientContract callback = null;
            MessageEventHandler messageHandler = null;
    
            public void Subscribe()
            {
                callback = OperationContext.Current.GetCallbackChannel<IClientContract>();
                messageHandler = new MessageEventHandler(Publish_NewMessageEvent);
                MessageEvent += messageHandler;
            }
    
            public void Unsubscribe()
            {
                MessageEvent -= messageHandler;
            }
    
            public void PublishMessage(DateTime timeStamp, DataTable table)
            {
                ServiceEventArgs se = new ServiceEventArgs();
                se.timeStamp = timeStamp;
                se.table = table;
                MessageEvent(this, se);
            }
    
            public void Publish_NewMessageEvent(object sender, ServiceEventArgs e)
            {
                try
                {
                    // This callback was causing the error, as the client would no longer exist but the channel would still be open and trying to receive the message
                    callback.ReceiveMessage(e.timeStamp, e.table);
                }
                catch
                {
                    // Unsubscribe the dead client.
                    Unsubscribe();
                }
            }
