    public class EventFoo
    {
        public EventFoo()
        {
            Tasks = new List<Task>();
        }
        public List<Task> Tasks { get; private set; }
    
        public EventFoo Add(Task task)
        {
            Tasks.Add(task);
            return this;
        }
    }
