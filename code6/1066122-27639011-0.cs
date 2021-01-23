    private void OnSelectedPlayersChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                if (this.SelectionMode == Mode.Once)
                {
                    SynchronizationContextProvider.UIThreadSyncContext.Post((d) =>
                    {
                        this.SelectedPlayers.Clear();
                        this.SelectedPlayers.Add((Players)e.NewItems[0]);
                    }, null);
                }
            }
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                //some logic
            }
    }
