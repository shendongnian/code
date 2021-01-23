    public class TaskClassMap : ClassMap<Task>
    {
        public TaskClassMap()
        {
            Table("Task");
            Id(task => task.Id, "taskid");
            HasMany(c => c.Applications)
                .KeyColumn("task_id");
        }
    }
