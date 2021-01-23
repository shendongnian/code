    public string RemainingTime
    {
        get {
               Task.Delay(1000).
               ContinueWith(w => OnPropertyChanged(() => RemainingTime));
               return (CurrentServerTime - SelectedDeliveryTime).ToString("mm\\:ss");
            }
    }
