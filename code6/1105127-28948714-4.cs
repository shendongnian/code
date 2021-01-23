    // generated code
    public partial class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public int? AssignedUserId { get; set; }
    }
    public class User
    {
        public int UserId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
    // your code
    public partial class Project
    {
        [ForeignKey("AssignedUserId")]
        public User User { get; set; }
    }
