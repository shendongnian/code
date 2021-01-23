    public abstract class Document
    {
        public int Id { get; set; }
        public string NameOnDocument { get; set; }
        public virtual string Number
    }
    
    public class BirthCertificate : Document
    {
        [Display(Name="RegistrationNumber"]
        [Required]
        public override string Number { get; set; }
    }
    
    public class Licence : Document
    {
        [Display(Name="LicenceNumber"]
        [Required]
        public override string Number { get; set; }
    }
