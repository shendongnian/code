     public class ItemProduction 
    {
        public string Main { get; set; }
        public DateTime itemDate { get; set; }
        public string ItemType { get; set; }
        public string productionId { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
        public ItemProduction()
        {
            Main = "main value";
            itemDate =DateTime.Now;
            ItemType ="type";
            productionId ="productionId";
            Quantity =5;
            Status = "status";
        }
    }
