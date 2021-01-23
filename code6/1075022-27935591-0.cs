    [XmlRoot("ResponseServiceHeader")]
    public class ServiceHeader : SoapHeader
    {
         public string TransactionID{get;set;}
         public string TransactionDate{get;set;}
    }
