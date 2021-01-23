    [DelimitedRecord(",")] 
    public class contactTemplate
    {
      [FieldQuoted('"', QuoteMode.OptionalForBoth)]
      public string firstName;
      [FieldQuoted('"', QuoteMode.OptionalForBoth)]
      public string lastName;
    }
