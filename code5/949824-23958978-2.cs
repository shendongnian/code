        public class InventoryIndexViewModel
        {
            public InventoryIndexViewModel()
            {
				Receivers = new List<Receiver>();
            }
            public bool IsDeleteReceiverButtonVisible { get; set; }
            public IList<Receiver> Receivers { get; set; }
        }
        public class Receiver
        {
            public Cooperative Cooperative { get; set; }
        }
        public class Cooperative
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
