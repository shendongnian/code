    class ActivityWrapper : IActivity {
        private readonly IActivity _activity;
        public ActivityWrapper(IActivity activity) {
            _activity = activity;
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
