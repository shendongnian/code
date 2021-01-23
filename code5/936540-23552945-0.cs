    private Func<Order, OrderResult> GetDispatcherForOrder(Order order)
    {
        switch (order.Type)
        {
            case "A":
                return dispatcher => DispatchA(order.Id, order.Info, ...);
            case "B":
                return dispatcher => DispatchB(order.Id, order.Info, ...);
            default:
                throw new ArgumentOutOfRangeException("order.Type");
        }
    }
    Order x = GetOrder();
    Func<Order, OrderResult> myFunction = GetDispatcherForOrder;
    OrderResult myResult = myFunction(x);
