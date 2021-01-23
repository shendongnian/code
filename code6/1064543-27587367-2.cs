    public ViewResult Index(int? customerId = null)
    {
        if(cusomerId == null)
        {
            return new IndexModel {Customers = customersList};
        }
        else
        {
            return new IndexModel {Customers = customersList, Details = getDetailsById(customerId)};
        }
    }
