    [Route("api/customers/{customerId:int}")]
    public Customer GetCustomerInformation(int customerId, bool includeTotalSales, bool includeAverageSalesMonth)
    {
        var customer = new Customer { CustomerId = customerId };
        customer.TotalSalesAmount = includeTotalSales ? CalculateTotalSales(customerId) : null;
        // etc
    }
