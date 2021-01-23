    class Activity
    {
        public List<Activity> ChildActivities { get; private set; }
        public Activity()
        {
            ChildActivities = new List<Activity>();
        }
    }
    class Factory : Activity { }
    class Workstation : Activity { }
