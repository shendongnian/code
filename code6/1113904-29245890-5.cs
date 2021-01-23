    public class UserCreateVM
    {
      [Display(Name = "Code Name")]
      [Required(ErrorMessage = "Please enter a code name")]
      public string CodeName { get; set; }
      [Display(Name = Use Brief Instructions?")]
      public bool UseBriefInstructions { get; set; }
      [Display(Name = Device")]
      [Required(ErrorMessage = "Please select a device")]
      public int? SelectedDevice { get; set; }
      public SelectList DeviceList { get; set; }
    }
