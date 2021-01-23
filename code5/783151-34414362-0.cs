    private bool RemovePopup()
    {
       if (ppChangePIN == null || !ppChangePIN.IsOpen) 
          return false;
       ppChangePIN.IsOpen = false;
       return true;
    }
    protected override void OnBackKeyPress(CancelEventArgs e)
    {
      if (RemovePopup())
        e.Cancel = true;
    }
