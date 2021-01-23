    public class AspNetUsers
    {
        [Key]
        public string Id { get; set; }
        public string UserName { get; set; }
        public int? ContactID { get; set; }
        [ForeignKey("ContactID")]
        public Contact Contact { get; set; }
        public ICollection<AspNetRoles> Roles { get; set; } 
    }
   
    public class AspNetRoles
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<AspNetUsers> Users { get; set; } 
    }
