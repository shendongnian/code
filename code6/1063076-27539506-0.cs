    public class CustomerDetailsService : Service
    {
        public CustomerDetailsResponse Get(CustomerDetails request)
        {
            var customer = Db.SingleById<Customer>(request.Id);
            using (var orders = base.ResolveService<OrdersService>())
            {
                var ordersResponse = orders.Get(new Orders { CustomerId = customer.Id });
                return new CustomerDetailsResponse
                {
                    Customer = customer,
                    CustomerOrders = ordersResponse.Results,
                };
            }
        }
    }
