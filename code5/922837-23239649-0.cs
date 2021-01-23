    [IgnoreFirst(2)]
    [DelimitedRecord(",")]
    public class LogData
    {
        public Double TimeStamp;
        [FieldNullValue(0.0)]
        [FieldOptional, FieldArrayLength(0, 100)]
        public Double[] ManyFields;
    }
