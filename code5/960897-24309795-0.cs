    public ViewModelA
    {
        public ViewModelA()
        {
            StateController.Instance.PropertyChanged += StateController_PropertyChanged;
        }
    
        void StateController_PropertyChanged(object sender, NotifyPropertyChangedEventArgs e)
        {
            // if singleton's ShowImages property changed, raise change 
            // notification for this class's ShowImages property too
            if (e.PropertyName == "ShowImages")
                OnPropertyChanged("ShowImages");
        }
    
        public bool ShowImages
        {
            get { return StateController.Instance.ShowImages; }
            set { StateController.Instance.ShowImages = value; }
        }
    }
