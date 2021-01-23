    try
    {
        LocalMessageReceiver receiver = new LocalMessageReceiver("There can be only one");
        receiver.Listen();
        receiver.MessageReceived += receiver_MessageReceived;
    }
    catch (ListenFailedException)
    {
        log.Info("Another instance is running.");
        // Display message, take corrective action etc.
        interactionService.ShowMessage(Strings.OneInstanceAllowed,
                                               Strings.ApplicationName, DialogButton.OKCancel, DialogImage.Question,
                                               OnCloseClientResponse);
    }
