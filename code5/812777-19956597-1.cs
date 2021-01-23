    ActiveXComponent activex = new ActiveXComponent();
    activex.OnMessage += ProcessMessage;
    activex.StartThread();
    public void ProcessMessage(object sender, NewMessageArgs args)
    {
        var msg = args.Message;
        //process
    }
