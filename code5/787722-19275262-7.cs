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
        internal void CalculateLineItemTotal()
        {
            // calculate the TotalPrice per lineitem
            foreach (var item in Body.LineItems)
            {
                item.TotalPrice = item.ItemPrice * item.ItemNumber;
            }
        }
        internal void CalculateFooterTotals()
        {
            // summerize the lineitems values in the footer
            Footer.TotalItems = Body.LineItems.Sum(x => x.ItemNumber);
            Footer.TotalPrice = Body.LineItems.Sum(x => x.TotalPrice);
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
