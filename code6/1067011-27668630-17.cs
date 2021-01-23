    public class BaseCard
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
    }
    public class Skill
    {
        [Key]
        public int Id { get; set; }
        public int BaseCardId { get; set; }
       [ForeignKey("BaseCardId")]
        public virtual BaseCard BaseCard { get; set; }
    }
