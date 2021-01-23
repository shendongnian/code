    [DataContract]
    public class Entity
    {
        [DataMember]
        public int? Temp { get; set; }
        [Description]
        public int? DbTemp { get; set; }
        [OnSerializing()]
        internal void OnSerializingMethod(StreamingContext context)
        {
            Temp = DbTemp;
        }
    }
