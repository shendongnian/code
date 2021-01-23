    namespace ABMCEditAndReports.Models
    {
        public class LogInViewModel
        {
            [Display(Name = "User Name")]
            public string UserName { get; set; }
            
            [Display(Name = "Password")]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }
    }
