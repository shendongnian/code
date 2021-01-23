    [MustBeCreatorEditorPublisher]
    public class Role
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a role name")]
        public string Name { get; set; }
        public bool IsCreator { get; set; }
        public bool IsEditor { get; set; }
        public bool IsPublisher { get; set; }
    }
