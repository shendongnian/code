     public bool Checked
            {
                get
                {
                    return isToggleOn;
                }
                set
                {
                    onPropertyChanged();
                    isToggleOn = value;
                }
    
            }
