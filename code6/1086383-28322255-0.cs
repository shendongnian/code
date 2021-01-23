    public partial class Person1
    {
        public int PersonID { get; set;     
        public string Title { get; set; }
        public string FirstName { get; set; }       
        public string LastName { get; set; }      
        public string UserName { get; set; }
        public Nullable<int> UserAuthRoleId { get; set; }
        public virtual Password Password { get; set; }
    }
