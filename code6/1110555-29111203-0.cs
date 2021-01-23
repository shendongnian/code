    public class VoziloVM
    {
      [Display(Name = "Vozilo")]
      [Required(ErrorMessage = "Please select a Vozilo")]
      public int? SelectedVozilo { get; set; }
      public SelectList VoziloList { get; set; }
    }
