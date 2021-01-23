    public class User
    {
        public int ID { get; set; }
        public string FullName { get; set; }
    
        //added ID    
        public int OrganizationID { get; set; }
        public virtual Organization Organization { get; set; }
        // [...]
    }
