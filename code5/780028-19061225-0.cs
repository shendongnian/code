    class Model : MvxNotifyPropertyChanged
    {
       public string A { 
            get { return _a; } 
            set { _a = value; RaisePropertyChanged(() => A); }
       }
    }
