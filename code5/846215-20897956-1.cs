    private SynchronizationContext uiContext = SynchronizationContext.Current;
    public void PLCMessage_Received(object sender, PLCMessageEventArgs e)
    {
        string tempstr = (String)e.Message;
        uiContext.Send((x)=> UpdateGUI(tempstr), null);//For synchronous
        //Or
        uiContext.Post((x)=> UpdateGUI(tempstr), null);//For Asynchronous
    }
