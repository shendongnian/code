    public class RegisterViewModel
    {
        [Display(Name = "FirstName")]
        [Required]
        public string FirstName { get; set; }
    
        public bool isTrue
        { get { return true; } }
    
        [Display(Name = "Verify13")]
        [Required]
        [System.Web.Mvc.CompareAttribute("isTrue", ErrorMessage = "You must be 13 of age or     older to receive email updates.")]
        public bool Is13 { get; set; }
    }
