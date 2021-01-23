    public class InvoiceViewModel
    {
        public int invoiceID { get; set; }
        public string companyName { get; set; }
        public string currency { get; set; }
        public decimal? amt { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public string billerName { get; set; }
        public string attentedName { get; set; }
        public string status { get; set; }
    }
