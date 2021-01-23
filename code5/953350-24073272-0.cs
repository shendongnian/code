    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() 
        {
            this.StudyGroup = new List<StudyGroup>();
            this.Tests = new List<Test>();
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public virtual ICollection<StudyGroup> StudyGroup { get; set; }
        public virtual ICollection<Test> Tests { get; set; }
    }
