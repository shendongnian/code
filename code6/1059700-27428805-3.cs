    public IEnumerable<Detail> GetDetailsForOrders(IEnumerable<Orders> orderList)
    {
        foreach(var order in orderList)
        {
            foreach (var detail in order.Details)
            {
                yield return detail;
            }
        }
    }
    public decimal CalculateDiscount(IEnumerable<Order> ordersList)
    {
        return GetDetailsForOrders(ordersList).Sum(detail => detail.Discount);
    }
    public decimal CalculateTax(IEnumerable<Order> ordersList)
    {
        return GetDetailsForOrders(ordersList).Sum(detail => detail.Total) * taxRate;
    }
