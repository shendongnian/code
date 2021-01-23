    [Table("Participations")]
    public class Participation
    {
        [ForeignKey("ProjectID")]
        public virtual Project ProjectReference { get; set; }
        [ForeignKey("UserID")]
        public virtual UserProfile UserReference { get; set; }
    
        [Key, Column(Order = 0)]
        public int ProjectID { get; set; }
        [Key, Column(Order = 1)]
        public int UserID { get; set; }
        public Accessibility AccessLevel { get; set; }
    }
