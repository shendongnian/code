    // Data to be read and parsed.
    public class Returnable
    {
        public int Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }        
        public decimal Shipping { get; set; }
        public decimal Other { get; set; }
        public string Location { get; set; }
        public decimal Tax { get; set; }
    }
    // Data to Send Back:
    public class SendInformation
    {
         public string Tax { get; set; }
    }
