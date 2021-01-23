    public class CalculateProductPriceUseCase
    {
        private ICalculateProductPriceService _calculatePriceService;
        private IUnitOfWork _unitOfWork;
        public CalculateProductPriceUseCase(
            ICalculateProductPriceService calculatePriceService,
            IUnitOfWork unitOfWork)
        {
            _calculatePriceService = _calculatePriceService;
            _unitOfWork = unitOfWork;
        }
        public void Handle(Product product)
        {
            product.Price = _calculatePriceService.Calculate();
            
            _unitOfWork.Commit();
        }
    }
