    public class EditSoftwareTrackingViewModel 
    {
      public int Id { get; set; }
      [Display(Name="Software")]
      public int SoftwareId { get; set; }
      [Display(Name="Computer")]
      public int ComputerId { get; set; }
      [Display(Name="Software Action")]
      public int SoftwareActionId { get; set; }
      public SelectList Computers { get; set; }
      public SoftwareActions Computers { get; set; }
      public SelectList SoftwareList{ get; set; }
    }
