        [Serializable]
    public class create
    {
        public create()
        {
            vendor = new Vendor[0];
            customer = new Customer[0];
            asset = new Asset[0];
        }
        Vendor[] vendor { get; set; }
        Customer[] customer { get; set; }
        Asset[] asset { get; set; }
    }
    [Serializable]
    public class Vendor
    {
        public string vendorid { get; set; }
        public string name { get; set; }
        public string vcf_bill_siteid3 { get; set; }
    }
    [Serializable]
    public class Customer
    {
        public string CUSTOMERID { get; set; }
        public string NAME { get; set; }
    }
    [Serializable]
    public class Asset
    {
        public string createdAt { get; set; }
        public string createdBy { get; set; }
        public string serial_number { get; set; }
    }
