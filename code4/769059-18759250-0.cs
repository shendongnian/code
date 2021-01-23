    while(pipe.IsConnected && !isPipeStopped) //use a flag so that you can manually stop this thread
    {
        System.Threading.Thread.Current.Sleep(500);
    }
    if(!pipe.IsConnected)
    {
        //pipe disconnected
        NotifyOfDisconnect();
    }
