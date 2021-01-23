    private OrderResult GetDispatcherForOrder(Order order)
    {
        switch (order.Type)
        {
            case "A":
                return DispatchA(order.Id, order.Info, ...);
            case "B":
                return DispatchB(order.Id, order.Info, ...);
            default:
                throw new ArgumentOutOfRangeException("order.Type");
        }
    }
