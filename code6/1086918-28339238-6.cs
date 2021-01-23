    public class SomeService
    {
        public SomeService(IRepository<SomeItem> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }
        
        public void MarkItemCompleted(int itemId)
        {
            var item = repository.GetByKey(itemId);
            if(item != null)
            {
                item.Completed = true;
                unitOfWork.SaveChanges();
            }
        }
    }
