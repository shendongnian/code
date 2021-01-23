    public class User
    {
        public int Id { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public virtual ICollection<UserSkill> UserSkills { get; set; }
    }
    public class UserSkill
    {
        public int Id { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public Skill Skill { get; set; }
        
    }
    public class Skill
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<UserSkill> UserSkills { get; set; }
    }
