    try
	{
	 if(_unitOfWork==null)
	 {
	  _unitOfWork=(IUnitOfWork)DependencyResolver.Current.GetService(typeof(IUnitOfWork));
	 }
	  Product product = _unitOfWork.Products.First(p => p.Id == product_Id);
		// do long running task
	}
