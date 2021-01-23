    public class User : IUser
    {
        [Key]
        public string Id { get; set;}
        [Required]
        public UserType UserType { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 5)]
        public string UserName { get; set; }
    }
