    public class ApplicationVM
    {
      [Required]
      [DisplayName("First Name")]
      public string FirstName { get; set; }
      [Required]
      [DisplayName("Last Name")]
      public string LastName { get; set; }
      [Required]
      [DisplayName("Loan officer")]
      public int? LoanOfficer { get; set; } 
      public SelectList LoanOfficerList { get; set; }
    }
