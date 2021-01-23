    [DataContractAttribute]
    public class User
        {
            [DataMemberAttribute]
            private String field;
    
            public String _Field
            {
                get { return field; }
                set { field = value; }
            }
        }
