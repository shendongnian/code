    public partial class Request 
    {
        public virtual List<Approval> Approvals { get; set; }
    
        [NotMapped]
        public List<Approval> NotFlaggedApprovals
        {
            get 
            { 
                return Approvals == null ? new List<Approval>() : Approvals.Where(a => !a.Flagged).ToList(); 
            }
        } 
    }
