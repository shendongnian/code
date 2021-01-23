    [FixedLengthRecord]
    public class StudentData
    {
        [FieldFixedLength(20)]
        [FieldTrim(TrimMode.Right)] 
        public string name;
        [FieldFixedLength(3)]
        public string age;
        [FieldFixedLength(30)]
        [FieldTrim(TrimMode.Right)] 
        public string address;
        [FieldFixedLength(10)]
        public string bday;
        [FieldFixedLength(3)]
        public string level;
    }
