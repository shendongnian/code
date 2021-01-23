    public class Invoice
    {
        public string url { get; set; }
        public string contact { get; set; }
        public string dated_on { get; set; }
        public string due_on { get; set; }
        public string reference { get; set; }
        public string currency { get; set; }
        public string exchange_rate { get; set; }
        public string net_value { get; set; }
        public string sales_tax_value { get; set; }
        public string total_value { get; set; }
        public string paid_value { get; set; }
        public string due_value { get; set; }
        public string status { get; set; }
        public bool omit_header { get; set; }
        public int payment_terms_in_days { get; set; }
        public string paid_on { get; set; }
        public string comments { get; set; }
    }
    
    public class RootObject
    {
        public List<Invoice> invoices { get; set; }
    }
