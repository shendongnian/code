    public class PrioritizableTask
    {
        public PrioritizableTask(Task task, int taskPriority)
        {
            Task = task;
            Priority = taskPriority;
        }
        public int Priority { get; private set; }
        public Task Task { get; private set; }
    }
