    public CustomerValidator()
    {
        Custom((customer, validationContext) =>
        {
            var isValid = true;
            var failedOrders = new List<int>();
            for (var i = 0; i < customer.Orders.Count; i++)
            {
                if (customer.Orders[i].TotalValue > customer.MaxOrderValue)
                {
                    isValid = false;
                    failedOrders.Add(i);
                }
            }
            if (!isValid){
                var errorMessage = string.Format("Error: {0} orders TotalValue exceed maximum TotalValue allowed", string.Join(",", failedOrders));
                return new ValidationFailure("", errorMessage) // return indexes of orders through error message
                {
                    CustomState = GetOrdersErrorInfo(failedOrders) // set state object for parent model here
                };
            }
            return null;
        });
    }
