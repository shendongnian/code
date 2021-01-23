    public class Application
        {
            public virtual ApplicationId Id { get; set; }
        }
    
        public class ApplicationClassMap : ClassMap<Application>
        {
            public ApplicationClassMap()
            {
                Table("Application");
    
                CompositeId<ApplicationId>(app => app.Id)
                .KeyProperty(key => key.UserId, "user_id")
                .KeyReference(key => key.Task, "task_id")
                .KeyProperty(key => key.TransactionId, "transaction_id");
            }
        }
