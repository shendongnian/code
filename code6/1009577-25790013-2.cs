    <Button ... IsEnabled={Binding Path=ButtonIsEnabled} ...>
    class CalcViewModel:INotifyPropertyChanged
    {
        private CCalc _calc;
        private bool _buttonIsEnabled;
        public ButtonIsEnabled {
            get { return _buttonIsEnabled; }
            set { 
                _buttonIsEnabled = value;
                RaisePropertyChanged("ButtonIsEnabled");
            }
        }
    
        public int Counter
        {
            get
            { return _calc.Counter; }
            set{ 
                _calc.Counter = value;
                _buttonIsEnabled = _calc.Counter > 5;
            }
        }
        ...
    }
