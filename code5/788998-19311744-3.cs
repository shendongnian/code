    private bool _disableButton;
    
    public bool disableButton { 
                                  get { return _disableButton; }
                                  set { 
                                         _disableButton = value;
                                         SetValue(IsEnabledProperty, !_disableButton); 
                                      } 
                                 }
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
