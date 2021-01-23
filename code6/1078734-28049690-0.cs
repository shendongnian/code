    [Table("StudyLevel")]
    public class StudyLevelModel
    {
        [Key]
        public byte StudyLevelID { get; set; } 
        [Column("Level Description")]
        public string LevelDescription { get; set; }
        public string SLevelType { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string ESID { get; set; }
        public string RID { get; set; }
        public byte LevelSearchGroup { get; set; }
    }
