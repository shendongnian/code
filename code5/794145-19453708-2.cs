     private bool _isDirty;
     public bool IsDirty
            get
            {
                
                return _isDirty;
            }
            set
            {
                _isDirty = value
    
                _codeCollection = value;
                RaisePropertyChanged("IsDirty");
            }
