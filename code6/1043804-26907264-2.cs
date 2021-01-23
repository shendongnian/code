    public abstract class Document
    {
        public int Id { get; set; }
        public string NameOnDocument { get; set; }
    }
    public abstract class NumberedDocument : Document
    {
        public virtual string Number
    }
    public class BirthCertificate : NumberedDocument
    {
        [Display(Name="Registration Number"]
        [Required]
        public override string Number { get; set; }
    }
