    public class TeamToLeader
    {
        [Key]
        public int? TeamToLeaderId { get; set; }
        [ForeignKey("Team")]
        public int? TeamId { get; set; }
        [ForeignKey("SalesAgent")]
        public int AgentId { get; set; }
        public virtual Team Team { get; set; }       
        public virtual SalesAgent Agent { get; set; }
    }
