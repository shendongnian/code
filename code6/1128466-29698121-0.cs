    public class Audit
    {
        public bool IsDeleted { get; set; }
    
        public DateTime? DeletedDate { get; set; }
    
        public long? DeletedByUserId { get; set; }
    
        public DateTime CreatedDate { get; set; }
    
        public long CreatedByUserId { get; set; }
    
        public DateTime UpdatedDate { get; set; }
    
        public long UpdatedByUserId { get; set; }
    
        [TimeStamp]
        public byte[] RowVersion { get; set; }
    }
