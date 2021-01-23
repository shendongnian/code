    public class Role
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a role name")]
        public string Name { get; set; }
        [RequireTrue]
        public bool IsCreator { get; set; }
        [RequireTrue]
        public bool IsEditor { get; set; }
        [RequireTrue]
        public bool IsPublisher { get; set; }
    }
