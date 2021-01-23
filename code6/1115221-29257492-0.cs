    /// <summary>
    /// Raised when a new device is found on the network.
    /// </summary>
    public event EventHandler<EventArgs> NewBalance;
    public void ListenBalance()
    {
        SocketHandler.Socket.Handle.Add("balance", (m) =>
        {
            try
            {
                BalanceTest bt = m.Message.Json.GetFirstArgAs<BalanceTest>();
                SomeTest = bt;
                Messenger.Default.Send(new BalanceCommunicator { TestBalance = bt }, "Token");
    
                // Raise the event
                EventHandler<EventArgs> RaiseNewBalanceEvent = DeviceAttached;
                if (null != RaiseNewBalanceEvent)
                {
                    RaiseNewBalanceEvent(this, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message.ToString());
            }
        });
    }
    
