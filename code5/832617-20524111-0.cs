    public class Consult
    {
        public virtual Guid ID { get; set; }
    
        //etc
    
        [InverseProperty("Feedback")]
        public virtual ICollection<FeedbackRelation> ChildFeedbacks { get; set; }
    
        [InverseProperty("Consult")]
        public virtual ICollection<FeedbackRelation> ParentFeedbacks { get; set; }
    }
