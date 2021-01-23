    public class CreateEntityTask<T> : IEntityTask<Guid> 
    {
        /* The rest of code here */
        object IEntityTask.Result
        {
            get { return Task.Result; }
        }
    }
