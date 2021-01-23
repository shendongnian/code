    class Activity
    {
        public List<Activity> ChildActivities { get; private set; }
        public Activity()
        {
            ChildActivities = new List<Activity>();
        }
    }
    class Factory : Activity
    {
        public string City { get; private set; }
        public string Address { get; private set; }
    }
    class Workstation : Activity
    {
        public string WorkstationNumber { get; private set; }
    }
