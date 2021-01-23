    public class Person
    {
        [ForeignKey("profile"), Key]
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LearntSkillsAndLevelOfSkills { get; set; }
        public string ProfileImage { get; set; }
        public string City { get; set; }
        public string PhoneNr { get; set; }
        [Required]
        public string Email { get; set; }
        public string Hobbys { get; set; }
        public string SkillsToLearn { get; set; }
        public string Stand { get; set; }
        public int YearsOfWorkExperience { get; set; }
        public string HobbyProjectICTRelated { get; set; }
        public string ExtraInfo { get; set; }
        public string Summary { get; set; }
        public UserProfile profile { get; set; }
    }
