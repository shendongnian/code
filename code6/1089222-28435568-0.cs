    public class Appointee
    {
        [Key]
        public string ProfileID { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public string Ssn { get; set; }
        public string GrantNumber { get; set; }
        public virtual Case Case { get; set; }
    }
    public class Case
    {
        [Key, ForeignKey("Appointee")]
        public string ProfileID { get; set; }
        public int PSCStatusID { get; set; }
        [ForeignKey("ProfileID")]
        public virtual Appointee Appointee { get; set; }
    }
