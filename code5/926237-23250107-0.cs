    public class DeleteResource:AbstractCommand
    {
        public Guid ResourceId;
        public ResourceType Type;
    }
     public class DeleteResourceHandler:IExecute<DeleteResource>
    {        
        private IDispatchMessages _bus;
        private IStoreResources _repo;
        public DeleteResourceHandler(IStoreResources repo, IDispatchMessages bus)
        {
            _repo = repo;
            _bus = bus;
        }
        public void Execute(DeleteResource cmd)
        {
            _repo.Delete(cmd.ResourceId);
            var evnt = cmd.ToEvent();
            _bus.Publish(evnt); 
        }
    }
