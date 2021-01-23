    public class ProfitCenterRoot
    {
        public List<ProfitCenterItem> Data { get; set; }
        public ProfitCenterRoot()
        {
            Data = new List<ProfitCenterItem>();
        }
    }
    public class ProfitCenterItem
    {
        // Existing properties here
        public ProfitCenterItem()
        {
            Data = new List<ProfitCenterItem>();
        }
    }
