    public MainWindowViewModel()
    {
        ConnectEvents connectEvents = new ConnectEvents();
        ConnectViewModel = new ConnectViewModel(connectEvents);
        ConnectViewModel.SomethingHappenedEvent += HandleSomethingHappened;
        connectEvents.ThrowEvent += ConnectToServer;
    }
    private void HandleSomethingHappened(object sender, EventArgs e)
    {
        // Now your mainviewmodel knows that something happened
    }
