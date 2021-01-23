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
            Resource = new T();  // this is now a generic type
            Resource.Job = work.Assignment;
            Resource.Site = work.Site;
        //  ...
        }
    }
