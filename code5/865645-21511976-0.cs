    <!-- Your existing Control, Note `IsEnabled` is not bound -->
    <ToggleButton x:Name="SayHello" Height="40">
    // On your ViewModel
    public bool CanSayHello
    {
        get
        {
            return HasValue;
        }
    }
    public void Click()
    {
        HasValue = !HasValue;
        NotifyOfPropertyChange(() => CanSayHello);
    }
