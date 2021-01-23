    public class ProfileDetail
        {
    
            [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int ID { get; set; }
            public string UserName { get; set; }
            public string Age { get; set; }
            public string Location { get; set; }
            public string Gender { get; set; }
            public int ProfileMetaID { get; set; }
            public virtual ProfileMeta profileMeta { get; set; }
    
        }
    	public class ProfileMeta
        {
    
    [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
                public int ID { get; set; }
                public string Username { get; set; }
                public string password { get; set; }
                public virtual ProfileDetail profileDetail {get; set;}
            }
