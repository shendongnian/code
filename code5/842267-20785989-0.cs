    [XmlRoot("invoiceListResponse")]
    public class InvoiceListResponse
    {
        [XmlArray("invoiceList")]
        [XmlArrayItem("invoiceListItem")]
        public InvoiceDto[] InvoiceList;
    }
