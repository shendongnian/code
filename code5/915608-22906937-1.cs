    public class OrdersService : IDisposable {
        private readonly IOrdersRepository _orders;
        public ordersService(IOrdersRepository ordersRepo) {
            _orders = ordersRepo;
        }
    }
