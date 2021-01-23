    public class PrioritizableTasksCollection : IList<PrioritizableTask>
    {
        private static readonly List<PrioritizableTask> runners = new List<PrioritizableTask>();
        public void Add(PrioritizableTask item)
        {
            runners.Add(item);
        }
        public Task GetNextPriority()
        {
            var priorityTask = runners.OrderBy(x => x.Priority).FirstOrDefault();
            return priorityTask != null ? priorityTask.Task : null;
        }
    }
