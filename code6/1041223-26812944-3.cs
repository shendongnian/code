    public class LoanViewModel
    {
      [Required]
      [Display(Name="Select Item")]
      public string Item { get; set; }
      public SelectList ItemList { get; set; }
    }
