    public abstract class CreateBase
    {
    }
    public class Vendor : CreateBase
    {
        public string vendorid { get; set; }
        public string name { get; set; }
        public string vcf_bill_siteid3 { get; set; }
    }
    public class Customer : CreateBase
    {
        public string CUSTOMERID { get; set; }
        public string NAME { get; set; }
    }
    public class Asset : CreateBase
    {
        public string createdAt { get; set; }
        public string createdBy { get; set; }
        public string serial_number { get; set; }
    }
