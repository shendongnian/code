    public class UserModel()
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        [Required, StringLength(70)]
        public string Password { get; set; }
    }
