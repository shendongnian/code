    public class MyClass{
    
        [Required(ErrorMessage = "My validation error message goes here")] //give your validation message here
        [Display(Name = "My display name")] //Give your display name here
        public int NumDoc{ get; set; }
    }
