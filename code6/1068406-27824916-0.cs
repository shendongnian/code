    public class Document //or DocumentFile
    {
        public int DocumentId { get; set; }
        public string DocumentType { get; set; }
        public string FilePath { get; set; }
        [Index]
        public String Owner { get; set;} //exp. "Customer:Id", "Contact:Id"  maybe just int
        [Index]
        public String Reference { get; set; } //exp. "Invoice:Id", "Contract:Id"   maybe just int
        public DateTime TimeStamp { get; set; } //maybe int Reversion
    }
