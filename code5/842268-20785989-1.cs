    XmlSerializer s = new XmlSerializer(typeof(InvoiceListResponse));
    using (FileStream f = new FileStream("Test.xml", System.IO.FileMode.Open))
    {
        InvoiceListResponse response = (InvoiceListResponse)s.Deserialize(f);
    }
