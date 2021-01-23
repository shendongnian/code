    [FixedLengthRecord(",")]
    public class MyClass
    {
        [FixedLengthRecord(2)]
        public string RecordCode;
        [FixedLengthRecord(3)]
        public string CurrencyCode;
        [FixedLengthRecord(15)]
        public int CreditAmount;
        // etc.
    }
