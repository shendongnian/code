    public class ResumeSkillsListDataContract : IResumeSkillsListDataContract
    {
        public IList<SkillDataContract> KnownSkillsList { get; set; }
        public IList<SkillDataContract> BadSkillsList { get; set; }
        public IList<SkillDataContract> NewSkillsList { get; set; }
        public Int32 PersonId { get; set; } 
    }
