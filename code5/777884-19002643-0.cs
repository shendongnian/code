     private bool _isSelected;
            public bool IsSelected
            {
                get { return _isSelected; }
                set 
                { 
                    _isSelected = value;
                    if(_isSelected)
                        CurrentColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#73E34D"));
                    else
                        CurrentColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#5C8FFF"));
                    OnPropertyChanged("CurrentColor");
                }
            }
    
            private SolidColorBrush _currentColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#5C8FFF"));
            public SolidColorBrush CurrentColor
            {
                get { return _currentColor; }
                set { _currentColor = value; }
            }
