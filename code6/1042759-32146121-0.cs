    public string RemainingTime
    {
        get {
               Task.Delay(2000).
               ContinueWith(w => OnPropertyChanged(() => RemainingTime));
               return (SelectedDeliveryTime - CurrentServerTime).ToString("mm:ss");
            }
    }
