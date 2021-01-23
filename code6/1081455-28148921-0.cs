    public partial class SkillLevel
        {
            public int? SkillID { get; set; }
            public int? LevelID { get; set; }
            public string Description { get; set; }
            public string TestProcess { get; set; }
    
            public virtual Level Level { get; set; }
            public virtual Skill Skill { get; set; }
        }
