     public ActionResult Index()
     {
        TenantProvider provider = new TenantProvider(_unitOfWork);
        _otherRepository.DoWork();
        _unitOfWork.Save();
     }
