    public class TransactionUseCaseDecorator<T> : IUseCase<T>
    {
        private IUnitOfWork _unitOfWork;
        private IUseCase<T> _decoratedInstance;
        
        public TransactionUseCaseDecorator(IUnitOfWork unitOfWork,
            IUseCase<T> decoratedInstance)
        {
            _unitOfWork = unitOfWork;
            _decoratedInstance = decoratedInstance;
        }
        
        public void Handle(T useCase)
        {
            // Example: start a new transaction scope 
            // (or sql transaction or what ever)
            using (new TransactionScope())
            {
                _decoratedInstance.Handle(useCase);
                
                // Commit the unit of work.
                _unitOfWork.Commit();
            }
        }
    }
