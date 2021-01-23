    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class GetBooking
    {
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.w3.org/TR/html4/")]
        public Reservation Reservation { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.w3.org/TR/html4/")]
        public object Success { get; set; }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint Nmbr { get; set; }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Identifier { get; set; }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal Version { get; set; }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint Token { get; set; }
    }
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/TR/html4/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.w3.org/TR/html4/", IsNullable = false)]
    public partial class Reservation
    {
        public ReservationExtensions Extensions { get; set; }
    }
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/TR/html4/")]
    public partial class ReservationExtensions
    {
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.google.com/india")]
        public ReservationExt ReservationExt { get; set; }
    }
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.google.com/india")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.google.com/india", IsNullable = false)]
    public partial class ReservationExt
    {
        public ReservationExtExtPayTxInfo ExtPayTxInfo { get; set; }
    }
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.google.com/india")]
    public partial class ReservationExtExtPayTxInfo
    {
        public uint ReferenceID { get; set; }
        public string QueryRPH { get; set; }
        public byte Status { get; set; }
        public decimal Amount { get; set; }
        public byte Code { get; set; }
        public byte TxStatus { get; set; }
        public DateTime Timestamp { get; set; }
        public DateTime EndTimestamp { get; set; }
    }
