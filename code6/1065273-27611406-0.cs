    [DelimitedRecord(":")]
    public class Record
    {
      public string Name;
      [FieldTrim(TrimMode.Right,';')]
      public int Value;    
    }
