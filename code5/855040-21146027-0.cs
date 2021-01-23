    [DelimitedRecord(",")] 
    public class contactTemplate
    {
      [FieldQuoted('"', QuoteMode.OptionalForBoth)]
      public string CompanyName;
      [FieldQuoted('"', QuoteMode.OptionalForBoth)]
      public string fld2;
      // etc...
    }
