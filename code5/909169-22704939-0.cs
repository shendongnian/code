    [DataContract]
    public class MyObject
    {
        [DataMember]
        public Layer layer1 { get; set; }
    }
    [DataContract]
    public class Layer
    {
        [DataMember]
        public Side left { get; set; }
        [DataMember]
        public Side top { get; set; }
    }
    
    [DataContract]
    public class Side
    {
        [DataMember(Name="0")]
        public Color _0 { get; set; }
        [DataMember(Name = "1")]
        public Color _1 { get; set; }
        [DataMember(Name = "2")]
        public Color _2 { get; set; }
        [DataMember(Name = "3")]
        public Color _3 { get; set; }
    }
    [DataContract]
    public class Color
    {
        [DataMember]
        public byte r { get; set; }
        [DataMember]
        public byte g { get; set; }
        [DataMember]
        public byte b { get; set; }
    }
   
