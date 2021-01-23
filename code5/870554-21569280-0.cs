    public void DisplayLobbyWindow()
    {
        ...
            new LobbyWindow()
            {
                Owner = this,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            }.Show();
            this.Hide();
        ...
    }
