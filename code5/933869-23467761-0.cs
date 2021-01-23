    [DataContract]
    public class Frame
    {
        [DataMember]
        public string FrameName { get; set; }
        [DataMember]
        public string FrameTypeName
        {
            get
            {
                // or FrameType.FullName, depends on compatibility between client & server
                return FrameType != null ? FrameType.AssemblyQualifiedName : null;
            }
            set
            {
                FrameType = value != null ? Type.GetType(value, true) : null;
            }
        }
        // don't serialize this one
        [IgnoreDataMember]
        public Type FrameType { get; set; }
    }
