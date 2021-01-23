    public partial class Invoice
    {
        public Invoice()
        {
        }
        [XmlElement("Dates")]
        public List<Dates> Dates { get; set; }
        // and so on.
    }
