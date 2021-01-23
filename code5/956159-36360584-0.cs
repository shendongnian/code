    namespace WebOrders
    {
        public class OrderListItem
        {
            [DisplayName(@"WebOrderID")]
            public string WebOrderId { get; set; }
            [DisplayName(@"ID")]
            public string Id { get; set; }
            public string Location { get; set; }        
    
            public OrderListItem()
            {
            }
        
            public OrderListItem(string weborderId, string id, string location)
            {
                WebOrderId = weborderId;
                Location = location;
                Id = id;            
            }
        }
    }
