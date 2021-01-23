    public class OrderListVM 
    {
        
        ViewModelFactory _factory;
        IEnumerable<IOrder> _orderList;
        public OrderListVM(ViewModelFactory factory, IEnumerable<IOrder> orders)
        {
            _factory = factory;
            _orderList = orders;
        }
        public void OnNewOrder()
        {
            var myOrderVM = _factory.GetOrderVM();
            myOrderVM.Show();
        }
    }
OrderVM
    public class OrderVM 
    {
        IOrder _order;
        public OrderVM(IOrder order)
	    {
            _order = order;
	    }
    }
ViewModelFactory
    interface IViewModelFactory { ... }
    public class ViewModelFactory : IViewModelFactory 
    {
        IOrderRepository _repository;
        public ViewModelFactory (IOrderRepository repo)
        {
            _repository = repo;
        }
        public OrderListVM GetOrderListVM() {
            return new OrderListVM(this, _repository.GetAll());
        }
        public OrderVM GetOrderVM(IOrder order = null) {
            if (order == null) {
                order = _repository.CreateNewOrder();
            }
            return new OrderVM(order);
        }
    }
