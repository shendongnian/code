    public class TenancyVM
    {
      [Required(ErroMessage = "Please select tenancy")]
      [Display(Name = "Tenancy")]
      public int? TenancyID { get; set; }
      ....
      public SelectList TenancyList { get; set; }
    }
