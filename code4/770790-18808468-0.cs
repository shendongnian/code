    [Table(Name = "Customer")]
    public class Customer
    {
        [Column(IsPrimaryKey = true, Name = "ID")]
        public int ID { get; set; }
        [Column(Name = "Name")]
        public string Name { get; set; }
        [Association(Name = "Customer_Purchases", ThisKey = "ID", OtherKey = "CustomerID")]
        public EntitySet<Purchase> PurchaseList { get; set; }
        public List<Purchase> Purchases
        {
            get
            {
                return new List<Purchase>(PurchaseList.AsEnumerable());
            }
        }
    }
    [Table(Name = "Purchase")]
    public class Purchase
    {
        [Column(IsPrimaryKey = true, Name = "ID")]
        public int ID { get; set; }
        [Column(Name = "CustomerID")]
        public int CustomerID { get; set; }
        [Column(Name = "Description")]
        public string Description { get; set; }
        [Column(Name = "Price")]
        public decimal Price { get; set; }
    }
