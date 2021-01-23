    public class Project<T> where T : Resource, new()
    {
        public T Resource { get; set; }  // will need to handle other classes as well
        public String Task { get; set; }
        // ctor
        public Project(String task)
        {
            Task = task;
        }
        // current method
        public void DoWork()
        {
            var work = new Work(this.Task);
            Resource resource = new T();  // this instance of Person could be other objects as noted
            resource.Job = work.Assignment;
            resource.Site = work.Site;
        //  ...
        }
    }
