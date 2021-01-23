    public SomeViewModel : ViewModelBase // assuming that you have a base class for this
    {
        public string CurrentGroupCode
        {
            get { return Groups.CurrentItem.Code; }
            set
            {
                 Groups.CurrentItem.Code = value;          // assuming that the VM has been intialized correctly
                 RaisePropertyChanged("CurrentGroupCode"); // implemented in base class
            }
        }
        /*
         * ...Initialization, logic a.s.o.
         */
    }
