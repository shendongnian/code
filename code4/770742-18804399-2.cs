    public class UnitOfWorkProxy : IUnitOfWork
    {
        private Lazy<IUnitOfWork> uow;
    
        public UnitOfWorkProxy(Lazy<IUnitOfWork> uow)
        {
            this.uow = uow;
        }
    
        void IUnitOfwork.SubmitChanges()
        {
            this.uow.Value.SubmitChanges();
        }
        
        // TODO: Implement All other IUnitOfWork methods
    }
