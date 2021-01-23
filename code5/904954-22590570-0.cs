    // this is the original class you have
    public class CompanyDetails
    {
        public string Company { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string SalesPerson { get; set; }
    }
    //this is to help you with the display
    public class GrouppedCompanyDetails
    {
        public string Address { get; set; }
        public List<string> SalesPerson { get; set; }
    }
