    public partial class BusinessPartner {
        public long Id {get; set; }
        public string Name {get; set; }
        public BusinessPartnerType Type {get; set; }
    }
    
    public enum BusinessPartnerType {
        Customer = 1,
        Supplier = 2
    }
