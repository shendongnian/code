    sealed class AssigningInfo : IReadonlyAssigningInfo {
        private readonly List<AssignedTasks> _assignedTasks;
        ...
        public IEnumerator<IReadonlyAssignedTasks> GetEnumerator()
        {
            return _assignedTasks.GetEnumerator();
        }
    }
