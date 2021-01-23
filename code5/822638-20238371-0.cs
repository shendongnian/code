    public class InvoiceHeader
    {
        public string CustomerName { get; set; }
        
        public int Number { get; set; }
        
        public DateTime Date { get; set; }
    }
    public class InvoiceBody
    {
        public int Sum { get; set; }
        
        public string Currency { get; set; }
    }
    
    public class Invoice
    {
        private readonly InvoiceHeader header = new InvoiceHeader();
        
        public InvoiceHeader Header {
            get {
                return header;
            }
        }
        
        private readonly InvoiceBody body = new InvoiceBody();
        
        public InvoiceBody Body {
            get {
                return body;
            }
        }
    }
