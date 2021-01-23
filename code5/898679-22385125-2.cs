    [DataContract]
    public class YoloClassRO
    {
        private int k = 42;
        [DataMember]
        public int K 
        {
            get { return k; }
        }
    }
    [DataContract]
    public class YoloClassRW
    {
        private int k = 42;
        [DataMember]
        public int K
        {
            get { return k; }
            set { k = value; }
        }
    }
