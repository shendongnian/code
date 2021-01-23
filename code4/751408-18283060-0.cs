    [ProtoContract]
    [ProtoInclude(3, typeof(CustomSourceTableResponse), DataFormat = DataFormat.Group)]
    public class CustomBaseResponse
    {
        [ProtoMember(1)]
        public bool Success { get; set; }
        [ProtoMember(2)]
        public string Error { get; set; }
    }
    [ProtoContract]
    public class CustomSourceTableResponse : CustomBaseResponse
    {
        [ProtoMember(1, DataFormat = DataFormat.Group)]
        public List<FieldTable> FieldValuesByTableName { get { return fieldValuesByTableName; } }
        private readonly List<FieldTable> fieldValuesByTableName = new List<FieldTable>();
    }
    [ProtoContract]
    public class FieldTable
    {
        public FieldTable() { }
        public FieldTable(string tableName)
        {
            TableName = tableName;
        }
        [ProtoMember(1)]
        public string TableName { get; set; }
        [ProtoMember(2, DataFormat = DataFormat.Group)]
        public List<FieldValue> FieldValues { get { return fieldValues; } }
        private readonly List<FieldValue> fieldValues = new List<FieldValue>();
    }
    [ProtoContract]
    public class FieldValue
    {
        public FieldValue() { }
        public FieldValue(string name, string value)
        {
            Name = name;
            Value = value;
        }
        [ProtoMember(1)]
        public string Name { get; set; }
        [ProtoMember(2)]
        public string Value { get; set; }
    }
