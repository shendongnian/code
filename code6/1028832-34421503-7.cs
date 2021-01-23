    public class TaskFields
    {
        public string Title { get; set; }
        public string Activity { get; set; }
    }
    public class CreateTaskInput
    {
        public int Id { get; set; }
        public TaskFields TaskProperties { get; set; }
    }
