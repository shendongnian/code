    public class Report
    {
        // typical simple property in report
        public string ReportUid { get; set; }
        // object properties
        public Header Header { get; set; }
        public Body Body { get; set; }
        public Footer Footer { get; set; }
        public Report()
        {
            Header = new Header();
            Body = new Body();
            Footer = new Footer();
        }
        internal void CalculateFooterTotals()
        {
            // summerize the lineitems values in the footer
            Footer.TotalItems = Body.LineItems
                .Sum(x => x.Quantity);
            Footer.TotalPrice = Body.LineItems
                .Sum(x => x.Total);
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
        public int Quantity { get; set; }
        public float ItemPrice { get; set; }
        // computed 
        public float Total
        {
            get { return Quantity * ItemPrice; }
        }
    }
    public class Footer
    {
        // populated via report.CalculateFooterTotals()
        public int TotalItems { get; internal set; }
        public float TotalPrice { get; internal set; }
    }
