    [FixedLengthRecord(FixedMode.ExactLength)]
    public class MyClass{
        [FieldFixedLength(7)]
        [FieldConverter(typeof(PaddedIntConverter), 7)]
        public int RecordCount;
    }
