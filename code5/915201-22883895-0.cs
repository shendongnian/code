    public class CustomerInvoice
    {
      // we're only modifing the tax rate
      public decimal TaxRate { get; set; }
     
      // everything else gets stored here
      [JsonExtensionData]
      private IDictionary<string, JToken> _additionalData;
    }
    
    string json = @"{
      'HourlyRate': 150,
      'Hours': 40,
      'TaxRate': 0.125
    }";
     
    var invoice = JsonConvert.DeserializeObject<CustomerInvoice>(json);
     
    // increase tax to 15%
    invoice.TaxRate = 0.15m;
     
    string result = JsonConvert.SerializeObject(invoice);
    // {
    //   'TaxRate': 0.15,
    //   'HourlyRate': 150,
    //   'Hours': 40
    // }
