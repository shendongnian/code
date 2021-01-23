    public class DeviceTechnologyModel
    {
            public int Id { get; set; }
            [Required(ErrorMessage = "*")]
            [Display(Name = "Device Technology")]
            public string Name { get; set; }
            [Required(ErrorMessage = "*")]
            [Display(Name = "Alias")]
            public string Alias { get; set; }
            [Required]
            [Required(ErrorMessage = "*")]
            [Display(Name = "Device vendors")]
            public int VendorId { get; set; }
            public List<string> Vendors { get; set; }
    }
