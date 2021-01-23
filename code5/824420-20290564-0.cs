    public static class OrderStatesExtensions
    {
        public static bool Is(this int n, OrderStatesstate)
        {
            return (States) n == state;
        }
        public static bool Is(this OrderStates state, int n)
        {
            return n.Is(state);
        }
    }
    // usage
    order.State.Is(OrderStates.Something)
