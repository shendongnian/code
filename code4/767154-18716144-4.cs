    public class CalculateProductPrice
    {
        public int ProductId { get; set; }
    }
    public class CalculateProductPriceUseCaseHandler
        : IUseCase<CalculateProductPrice>
    {
        private ICalculateProductPriceService _calculatePriceService;
        private IUnitOfWork _unitOfWork;
        public CalculateProductPriceUseCaseHandler(
            ICalculateProductPriceService calculatePriceService,
            IUnitOfWork unitOfWork)
        {
            _calculatePriceService = _calculatePriceService;
            _unitOfWork = unitOfWork;
        }
        public void Handle(CalculateProductPrice useCase)
        {
            var product = _unitOfWork.Products.GetById(useCase.ProductId);
            
            product.Price = _calculatePriceService.Calculate();
        }
    }
