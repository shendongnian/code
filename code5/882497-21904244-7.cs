    class Activity
    {
        // An attribute that every Activity may need: a displayable name.
        // This might be useful if you have a TreeView, e.g., showing all the activities.
        public string Name { get; private set; }
        // Every Activity could have child activities - this is the Composite pattern.
        // You can loop through these to navigate through the hierarchy of your data.
        // (This is often done using recursion; see example below with GetAllWorkstations().)
        public List<Activity> ChildActivities { get; private set; }
        public Activity()
        {
            ChildActivities = new List<Activity>();
        }
        public override string ToString() { return Name; }
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
