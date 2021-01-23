    public class ShopManager
    {
        [Inject]
        public IOrderNotification OrderNotification { get; set; }
    
        public int GetNotifyCount()
        {
            return OrderNotification.Count();
        }
    }
