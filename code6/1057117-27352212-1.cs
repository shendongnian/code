    public class Items
    {
        public readonly List<Product> ProdList;
        public readonly List<Employee> EmpList;
        public readonly List<ListProduct> BuyList;
        public readonly List<ListProduct> SellList;
        public readonly List<ListEmployee> EmpHours;
        private static Items _Instance;
        private Items() 
        {
            ProdList = new List<Product>();
            EmpList = new List<Employee>();
            BuyList = new List<ListProduct>();
            SellList = new List<ListProduct>();
            EmpHours = new List<ListEmployee>();
        }
        public static Items Instance
        {
            get { return _Instance ?? (_Instance = new Items()); }
        }
    }
