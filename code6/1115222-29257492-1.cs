    private void NewBalanceEventHandler(Object sender, EventArgs args)
    {
        // This will trigger the property changed event.
        Some = CM.SomeTest;
    }
    public BalanceViewModel()
    {
        try
        {
            CM = new CentralModel();
            CM.ListenBalance();
            Some = CM.SomeTest;
    
            // Attach to the NewBalance event
            // Note: you should detatch it again (with -=) when you've finished with it.
            CM.NewBalance += NewBalanceEventHandler;
        }
        catch (Exception ex)
        {
            System.Windows.MessageBox.Show(ex.Message.ToString());
        }
    }
