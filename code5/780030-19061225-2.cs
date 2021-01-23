    class MyViewModel : MvxViewModel
    {
       private readonly Model _m;
       public ModelWrapper(Model m) 
        { _m = m; }
       public string A { 
            get { return _m.A; } 
            set { _m.A = value; RaisePropertyChanged(() => A); }
       }
    }
