    public class TekeningViewModel : ViewModelBase
    {
        private readonly IUnitOfWorkAsync _unitOfWork;
        TekeningViewModel(IUnitOfWorkAsync _unitOfWork){
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("unitOfWork");
            }
            _unitOfWork = unitOfWork;
        }
    }
