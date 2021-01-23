        public string InvoiceXml { get; set; }
        
        public InvoiceSnapshot Invoice
        {
            get 
            { 
                return this.InvoiceXml != null 
                    ? InvoiceSnapshot.Parse(this.InvoiceXml)
                    : null; 
            }
            set { this.InvoiceXml = value != null ? value.ToXml() : null; }
        }
        
