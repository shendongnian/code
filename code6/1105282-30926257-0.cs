    class ActivityWrapper : IActivity
    {
        private readonly IActivity _activity;
        public ActivityWrapper(IActivity activity)
        {
            _activity = activity;
            _activity.PropertyChanged += _activity_PropertyChanged;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        void _activity_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, e);
        }
        public string Id
        {
            get { return _activity.Id; }
        }
        public bool IsEnabled
        {
            get { return _activity.IsEnabled; }
        }
    }
