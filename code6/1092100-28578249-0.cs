    public class UserDetailsModel
    {
        public int Id { get; set; }
        [Required]
        public string UserType { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        [Display(Name = "Full name")]
        public string Fullname { get; set; }
        [RequiredIf("UserType", "Vendor", ErrorMessage = "Please Select City")]
        [Display(Name = "City")]
        public int? CategoryId { get; set; }
        public SelectList CityList { get; set; } // suggest this rather than ViewBag
    }
