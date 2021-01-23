    private bool CheckSingleInstance()
    {
        try
        {
            var receiver = new LocalMessageReceiver("application name", ReceiverNameScope.Global, LocalMessageReceiver.AnyDomain);
            receiver.Listen();
            return true;
        }
        catch (ListenFailedException)
        {
            // A listener with this name already exists
            return false;
        }
    }
