    public partial class Order
    {
        public OrderState GetOrderState()
        {
            return (OrderState)this.OrderState.Id;
        }
    }
