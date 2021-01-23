    [DataContract]
    public class CompositeType
        {
            [DataMember]
            public List<String> strlist = new List<String>();
            
            public List<String> StrList
            {
                get { return strlist; }
                set { strlist = value; }
    
            }
        }
