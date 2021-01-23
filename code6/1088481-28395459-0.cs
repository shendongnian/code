    class UserData : INotifyPropertyChanged {
        .... //set private fields
        public string DisplayName {
            get { return ....; }
            set {
                if (.... != value) {
                    .... = value;
                    OnPropertyChanged();
                }
            }
        }
        .... Other properties including an all purpose dictionary to keep custom data
    }
