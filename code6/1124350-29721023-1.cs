    namespace x.Dto
    {
        [DataContract]
        public class BlockDataDto<T>
        {
            [DataMember]
            public int RecordIndex { get; set; }
    
            [DataMember]
            public T Data { get; set; }
        }
    }
