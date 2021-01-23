    public decimal CalculateDiscount(IEnumerable<Order> ordersList)
    {
        return ordersList.SelectMany(ordersList.Detail).Sum(detail => detail.Discount);
    }
    public decimal CalculateTax(IEnumerable<Order> ordersList)
    {
        return ordersList.SelectMany(ordersList.Detail).Sum(detail => detail.Total) * taxRate;
    }
