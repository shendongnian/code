    [DataContract]
    public class TokenMessage
    {
        string tokenValue;
        string extraValue;
    
        bool enableExtraValue = true;
    
        [DataMember]
        public string Extra 
        {
            get { 
                    if (enableExtraValue) 
                          return extraValue;
                    return null; 
                }
            set { extraValue = value; }
        }
    
        [OnSerializing()]
        internal void OnSerializingMethod(StreamingContext context)
        {
            enableExtraValue = false;
        }
    
        [OnSerialized()]
        internal void OnSerializedMethod(StreamingContext context)
        {
            enableExtraValue = true;
        }
    }
