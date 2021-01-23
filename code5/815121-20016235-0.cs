      public class User
        {
            public string id { get; set; }
            public string name { get; set; }
            public string pwd { get; set; }
            [ForeignKey("roleId")]
            public string userrole { get; set; }
            public int roleId { get; set; }
        }
        
        public class userrole
        {
            public string id { get; set; }
            public string name { get; set; }
            public string description { get; set; }   
            public virtual ICollection<User> Users { get; set; }
    }
