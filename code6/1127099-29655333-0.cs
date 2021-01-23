    public Customer GetCustomerInformation(int customerId, LevelOfDetail detail 
      = LevelOfDetail.All)
    {
      var customer = new Customer { CustomerId = customerId };
      customer.TotalSalesAmount = detail.HasFlag(LevelOfDetail.TotalSalesAmount) ? CalculateTotalSales(customerId) : null;
      // etc
      return customer;
    }
    [Flags]
    public enum LevelOfDetail : int
    {
      TotalSalesAmount = (1 << 0),
      AverageSalesPerMonth = (1 << 1),
      All = TotalSalesAmount | AverageSalesPerMonth
    }
