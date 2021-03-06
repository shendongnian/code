    public class Report
    {
        public Header Header { get; set; }
        public Body Body { get; set; }
        public Footer Footer { get; set; }
        public Report()
        {
            Header = new Header();
            Body = new Body();
            Footer = new Footer();
        }
    }
    public class Header
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
    public class Body
    {
        public IList<LineItem> LineItems { get; set; }
        public Body()
        {
            LineItems = new List<LineItem>();
        }
    }
    
    public class LineItem
    {
        public string PartNumber { get; set; }
        public string PartDescription { get; set; }
        public int ItemNumber { get; set; }
        public float ItemPrice { get; set; }
        // probably computed (ItemNumber * ItemPrice)
        public float TotalPrice { get; set; }
    }
    public class Footer
    {
        // you'd have a routine to compute this
        // off of the lineitems
        public int TotalItems { get; set; }
        public float TotalPrice { get; set; }
    }
