    public class Application
    {
        public Task Task { get; set; }     // The relation/navigation property
    }
    internal class ApplicationMap : ClassMap<Application>
    {
        public ApplicationMap() : base()
        {
            Schema(...);
            Table(...);
    
            CompositeId()
                .KeyProperty(app => app.UserId, "...")
                .KeyReference(app => app.Task, "task_id")
                .KeyProperty(app => app.TransactionId, "...");
        }
    }
    
    internal class TaskMap : ClassMap<Task>
    {
        public TaskMap()
        {
            Schema(..);
            Table(...);
    
            Id(task => task.Id, "task_id");
    
            HasMany(task => task.Applications)
                .KeyColumn("task_id");
        }
    }
