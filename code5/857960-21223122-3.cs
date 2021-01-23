    private DateTime _lastUserActivity = DateTime.Now; 
    public DateTime LastUserActivity {
        set {
            _lastUserActivity = value;
        }
        get {
            return _lastUserActivity;
            OnPropertyChanged("LastUserActivity")
        }
    }
