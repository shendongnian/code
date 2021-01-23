    // command bound to close button sends the message
    private void YourCloseMainViewCommand()
    {
        Messenger.Default.Send(new CloseMessage(this));
    }
