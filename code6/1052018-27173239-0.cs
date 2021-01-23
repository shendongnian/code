	public Customer ImportCustomer(string customerCode)
	{
		var customer = GetCustomerByCode(string customerCode);
		if (customer == null)
		{
			customer = CreateCustomer();
		}
		return customer;
	}
	public Customer GetCustomerByCode(string customerCode)
	{
		var customer = this.unitOfWork.Customers.GetByCode(customerCode);
		return customer;
	}
	public Customer CreateCustomer()
	{
		var customer = new Customer{ \\.. here some initialization };
		return customer;
	}
