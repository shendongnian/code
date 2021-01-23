    using Orient.Client;
    namespace MyApplication
    {
        public abstract class ABaseModel
        {
            public ORID ORID { get; set; }
            public int OVersion { get; set; }
            public ORecordType OType { get; set; }
            public short OClassId { get; set; }
            public string OClassName { get; set; }
        }
    }
