    [DataContract]
    [KnownType(typeof(Extra))]
    [KnownType(typeof(Extra2))]
    public class TokenMessage
    {
        string tokenValue;
        string extraValue;
        [DataMember]
        public string Token
        {
            get { return tokenValue; }
            set { tokenValue = value; }
        }
        
    }
