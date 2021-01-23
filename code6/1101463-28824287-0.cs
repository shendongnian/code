    [DataContract(Name = "Invoice")]
    public class Invoice
    {
        [IgnoreDataMemberAttribute]
        public string Type { get; set; }
        [DataMember(Name = "InvoiceDate ", EmitDefaultValue = false)]
        public DateTime InvoiceDate { get; set;}
    }
    
