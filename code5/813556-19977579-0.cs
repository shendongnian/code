    [DataContract]
    public class CompositeType
        {
            [DataMember]
            public List<String> strlist ;
            
            public List<String> StrList
            {
                get { return strlist; }
                set { strlist = value; }
    
            }
        }
