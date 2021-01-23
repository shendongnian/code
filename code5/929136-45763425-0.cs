    [Key, Column(Order = 0)]
    public int UserId { get; set; }
    [Key, Column(Order = 1)]
    [ForeignKey("Skill")]
    public int SkillId { get; set; }
