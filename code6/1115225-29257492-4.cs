    /// <summary>
    /// Raised when a new balance is received.
    /// </summary>
    public event EventHandler<EventArgs> NewBalanceEvent;
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
                EventHandler<EventArgs> RaiseNewBalanceEvent = NewBalanceEvent;
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
    
