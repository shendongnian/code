    //Somewhere when initializing the connection
    _hubConnectionManager.StateChanged += OnHubConnectionManagerOnStateChanged;
    
    //Handler for state change
    private void OnHubConnectionManagerOnStateChanged(StateChange st)
	{
		//When disconnected, set state variable
		if (st.NewState == ConnectionState.Disconnected)
		{
			_wasDisconnected = true;
		}
		//If disconnected and we re-create connection successfully, re-subscribe to updates.
		if (_wasDisconnected && st.OldState == ConnectionState.Connecting && st.NewState == ConnectionState.Connected)
		{
			SubscribeToMachine(MachineStatusDetails.MachineId);
		}
		Messenger.Default.Send<ConnectionState>(st.NewState, UIMessageToken.ConnectionState);
	}
