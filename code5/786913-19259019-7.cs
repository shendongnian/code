    public class Context
    {
		private List<Customer> _customerList;
		private List<Product> _productList;
		public Context()
		{
			//Load All Lists here or in the following function instead
		}
		public List<TModel> CreateObjectSet<TModel>() where TModel : class
		{
			if (TModel is Customer) 
			{
				//you can load _customerList here instead of in constructor
				//check if _customerList is null then load it here for now and future use
				return _customerList;
			}
			if (TModel is Product)
			{
				//check if _productList is null then load it here for now and future use
				return _productList;
			}
			...
			throw...
		}
	}
