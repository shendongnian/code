    var orderWrapper = JsonConvert.DeserializeObject<OrderWrapper>(json);
    IEnumerable<Order> orders = result.GetOrders();
    public class OrderWrapper
    {
        [JsonProperty("orders")] 
        private Dictionary<string, Order> _orders;
        public IEnumerable<Order> GetOrders()
        {
            return _orders.Values;
        }
    }
