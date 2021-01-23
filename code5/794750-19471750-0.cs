    class OrderDisplay {
        private readonly Order _order;
        public OrderDisplay(Order order) {
            _order = order;
        }
        private string _orderNo;
        public string OrderNo {
            get {
                if (_orderNo == null) _orderNo = _order.GetOrderNo();
                return _orderNo;
            }
        }
        ...other properties...
    }
