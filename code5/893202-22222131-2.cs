    public class EditUserViewModel
    {
        public EditUserViewModel() { }
  
        // Allow Initialization with an instance of ApplicationUser:
        public EditUserViewModel(ApplicationUser user)
        {
            this.UserName = user.UserName;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.Email = user.Email;
        }
  
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
  
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
  
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
  
        [Required]
        public string Email { get; set; }
        //you might want to implement jobs too, if you want to display them in your index view
    }
