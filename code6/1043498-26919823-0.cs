    {
       ...
       Window.Current.Activated += Current_Activated;
       ...
    }
  
    void Current_Activated(object sender, Windows.UI.Core.WindowActivatedEventArgs e)
    {
        Debug.WriteLine(String.Format("Activated {0}", e.WindowActivationState));
    }
