    public abstract class Document
    {
        public int Id { get; set; }
        public string NameOnDocument { get; set; }
        public virtual string Number
    }
    
    public class BirthCertificate : Document
    {
        [Display(Name="Registration Number"]
        [Required]
        public override string Number { get; set; }
    }
    
    public class Licence : Document
    {
        [Display(Name="Licence Number"]
        [Required]
        public override string Number { get; set; }
    }
