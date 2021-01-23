    public bool disableButtton { get; set { SetValue(IsEnabledProperty, value); } }
    public new bool IsEnabled
        {
            get { return (bool)GetValue(IsEnabledProperty); }
            set
            {
                if(!disableButton)
                 {
                    SetValue(IsEnabledProperty, value);
                    SetImageFromState();
                 }
                    
            }
        }
