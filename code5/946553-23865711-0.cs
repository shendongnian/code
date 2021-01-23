    [Key, Column(Order = 0)]
    public int UserId { get; set; }
    [Key, Column(Order = 1)]
    public int QuestionGroupId { get; set; }
    [ForeignKey("UserId")]
    public virtual User User { get; set; }
    [ForeignKey("QuestionGroupId")]
    public virtual QuestionGroup QuestionGroup { get; set; }
