    namespace MVCMusicStore.Models
    {
        public class Login
        {
            [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required")]
            public string Name { get; set; }
    
            [Required(AllowEmptyStrings = false, ErrorMessage = "User Name is required")]
            public string UserName { get; set; }
    
            [DataType(DataType.Password)]
            [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
            public string Password { get; set; }
    
            [DataType(DataType.Password)]
            [Required(AllowEmptyStrings = false, ErrorMessage = "Confirm Password is required")]
            public string ConfirmPassword { get; set; }
    
            public string CountryList { get; set; }
    
            public List<SelectListItem> Country
            {
                get;
                set;
            }
    
            public string SelectedCountry { get; set; }
            public Login()
            {
                Bindcountry();
            }
    
            public void Bindcountry()
            {
                List<SelectListItem> coutryList = new List<SelectListItem>();
                coutryList.Add(new SelectListItem { Text = "India", Value = "India" });
                coutryList.Add(new SelectListItem { Text = "USA", Value = "USA" });
                coutryList.Add(new SelectListItem { Text = "UK", Value = "UK"});
                coutryList.Add(new SelectListItem { Text = "Mexico", Value = "Mexico" });
                coutryList.Add(new SelectListItem { Text = "Germany", Value = "Germany", Selected = true });
                coutryList.Add(new SelectListItem { Text = "France", Value = "France" });
    
                
                this.Country = coutryList;
                SelectedCountry = "Mexico";
                
            }
    
        }
    }
