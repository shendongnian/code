    public class KeynoteInformationRecord
    {
        public virtual int Id { get; set; }
        public virtual int KeynotePartId { get; set; }
        [StringLengthMax]
        public virtual string Title { get; set; }
        [StringLengthMax]
        public virtual string Description { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual bool HasEvaluation { get; set; }
        public virtual bool IsDeleted { get; set; }
    }
