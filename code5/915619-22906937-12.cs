    public class OrdersRepository : IOrdersRepository {
        private IDbConnection _db;
        public OrdersRepository(IDbConnection db) {
            _db = db;
        }
    }
