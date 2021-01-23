        public TenantController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _tenantRepository = unitOfWork.TenantRepository;
            _otherRepository = unitOfWork.OtherRepository;
        }
