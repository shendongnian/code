    public class TaskData
    {
        public Guid InternalId { get; private set; }
    
        public string Title { get; private set; }
    
        public string Details { get; private set; }
    
        public TaskState ExplicitState { get; private set; }
    
        public IEnumerable<TaskData> InnerTasks { get; private set; }
    
        public TaskState GetState(TaskData taskData)
        {
            if (!InnerTasks.Any())
                return taskData.ExplicitState;
    
            if (InnerTasks.All(x => this.GetState(x) == TaskState.Done))
            {
                return TaskState.Done;
            }
    
            if (InnerTasks.Any(x => this.GetState(x) == TaskState.InProgress))
            {
                return TaskState.InProgress;
            }
    
            return TaskState.Default;
        }       
    }
