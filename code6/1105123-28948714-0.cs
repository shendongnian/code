    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }
    }
    public class User
    {
        public int UserId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
