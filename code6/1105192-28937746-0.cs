    /// <summary>
                /// The <see cref="IsChecked" /> property's name.
                /// </summary>
                public const string IsCheckedPropertyName = "IsChecked";
        
                private bool _IsChecked = false;
        
                /// <summary>
                /// Sets and gets the IsChecked property.
                /// Changes to that property's value raise the PropertyChanged event. 
                /// </summary>
                public bool IsChecked
                {
                    get
                    {
                        return _IsChecked;
                    }
        
                    set
                    {
                        if (_IsChecked == value)
                        {
                            return;
                        }
        
                        RaisePropertyChanging(IsCheckedPropertyName);
                        _IsChecked = value;
                        RaisePropertyChanged(IsCheckedPropertyName);
                    }
                }
