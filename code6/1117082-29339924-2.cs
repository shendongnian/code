    public class Task
        {
            public virtual string Id { get; set; }
    
            public virtual IList<Application> Applications { get; set; }
        }
    
        public class TaskClassMap : ClassMap<Task>
        {
            public TaskClassMap()
            {
                Table("Task");
    
                Id(task => task.Id, "taskid");
                HasMany<Application>(c => c.Applications);
            }
        }
